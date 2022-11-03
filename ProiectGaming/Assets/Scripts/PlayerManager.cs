using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float HP = 1000;
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
        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(playerRigidBody.velocity.x) > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;

            //Animator
            //animator.SetFloat("Speed", 10);
        }
        else
        {
            if (isGrounded || playerRigidBody.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
                //Animator
                //animator.SetFloat("Speed", 0);
            }
        }

        // Change facing direction - Useful for future animation
        if (moveDirection != 0)
        {

            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                playerTransform.localScale = new Vector3(Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, base.transform.localScale.z);

            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                playerTransform.localScale = new Vector3(-Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);

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
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag != "Player")
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        playerRigidBody.velocity = new Vector2((moveDirection) * maxSpeed, playerRigidBody.velocity.y);
    }
}
