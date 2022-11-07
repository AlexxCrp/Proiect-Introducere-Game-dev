using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    public float HP = 1000f;
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
    //public Animator animator; WILL BE USED FOR ANIMATIONS AFTER DECIDING ON SPRITES, UNUSED FOR NOW
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
            //animator.SetFloat("Speed", 0);
        }

        // Movement controls

        bool keyIsA = Input.GetKey(KeyCode.A);
        if (keyIsA)
        {
            int value = -1;
            SetMoveDirection(value);

            // Change facing direction - Useful for future animation
            if (facingRight)
            {
                facingRight = false;
                playerTransform.localScale = new Vector3(value * Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
            }
        }

        bool keyIsD = Input.GetKey(KeyCode.D);
        if (keyIsD)
        {
            int value = 1;
            SetMoveDirection(value);

            // Change facing direction - Useful for future animation
            if (!facingRight)
            {
                facingRight = true;
                playerTransform.localScale = new Vector3(value * Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            //animator.SetBool("isJumping", true);

        }

        //if (isGrounded)
        //{
        //    animator.SetBool("isJumping", false);
        //}
        //else
        //{
        //    animator.SetBool("isJumping", true);
        //}


        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraPos.z);
        }

        healthbar.SetHealth(HP);
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = playerCollider.bounds;
        float colliderRadius = playerCollider.size.x * 0.4f * Mathf.Abs(base.transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Any(x => x.gameObject.tag != "Player"))
        {
            isGrounded = true;
        }

        // Apply movement velocity
        playerRigidBody.velocity = new Vector2((moveDirection) * maxSpeed, playerRigidBody.velocity.y);
    }

    private void SetMoveDirection(float value)
    {
        moveDirection = value;

        //Animator
        //animator.SetFloat("Speed", 10);
    }
}
