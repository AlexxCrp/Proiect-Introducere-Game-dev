using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using Debug = UnityEngine.Debug;

public class PlayerManager : MonoBehaviour
{
    public float HP = 1000f;
    public float MaxHp = 1000f;
    public Healthbar healthbar;
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    private Camera mainCamera;
    public bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D playerRigidBody;
    CapsuleCollider2D playerCollider;
    Transform playerTransform;
    public Animator animator;
    public float cameraDisplacementY = 1.35f;
    GameManager gameManager;
    /// <summary>
    /// Works as an observable. When set to true, turret consumes it (flips and resets to false).
    /// </summary>
    public bool hasFlipped = false;
    private GameObject weaponPickup;

    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        healthbar = GameObject.Find("Healthbar").GetComponent<Healthbar>();
        gameManager = GameManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(HP);
        playerTransform = base.transform;
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();

        playerRigidBody.freezeRotation = true;
        playerRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        playerRigidBody.gravityScale = gravityScale;

        facingRight = playerTransform.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded || playerRigidBody.velocity.magnitude < 0.01f)
        {
            moveDirection = 0;
            //Animator
            animator.SetFloat("Speed", 0);
        }

        // Movement controls

        bool keyIsA = Input.GetKey(KeyCode.A);
        if (keyIsA)
        {
            SetMoveDirection(-1);

            if (facingRight)
            {
                Flip();
            }
        }

        bool keyIsD = Input.GetKey(KeyCode.D);
        if (keyIsD)
        {
            SetMoveDirection(1);

            if (!facingRight)
            {
                Flip();
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            animator.SetBool("isJumping", true);
        }

        bool isInAir = !isGrounded;
        animator.SetBool("isJumping", isInAir);

        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position =
                new Vector3(playerTransform.position.x, playerTransform.position.y + cameraDisplacementY, cameraPos.z);
        }

        healthbar.SetHealth(HP);

        if (HP < 0)
        {
            HP = 0;
            gameManager.OpenGameOver();
        }
        if (HP > MaxHp)
        {
            HP = MaxHp;
        }

        if (Input.GetKeyDown(KeyCode.E) && weaponPickup != null)
        {
            PickupManager.PickUp(weaponPickup);
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = playerCollider.bounds;
        float colliderRadius = playerCollider.size.x * 0.4f * Mathf.Abs(base.transform.localScale.x);
        Vector3 groundCheckPos =
            colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);

        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = colliders.Any(x => x.gameObject.tag != "Player");

        // Apply movement velocity
        playerRigidBody.velocity = new Vector2(moveDirection * maxSpeed, playerRigidBody.velocity.y);
    }

    private void SetMoveDirection(float value)
    {
        moveDirection = value;

        //Animator
        animator.SetFloat("Speed", 10);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        playerTransform.Rotate(new Vector3(0, 180, 0), Space.Self);
        hasFlipped = true;
    }

    public void TakeDamage(float damage) => HP -= damage;

    public void Heal(float healAmmount) => HP += healAmmount;

    private void OnTriggerEnter2D(Collider2D pickup)
    {
        if (!pickup.gameObject.CompareTag("Pickup"))
        {
            return;
        }

        weaponPickup = pickup.gameObject;
    }

    private void OnTriggerExit2D(Collider2D pickup)
    {
        if (!pickup.GameObject().CompareTag("Pickup"))
        {
            return;
        }

        weaponPickup = null;
    }
}
