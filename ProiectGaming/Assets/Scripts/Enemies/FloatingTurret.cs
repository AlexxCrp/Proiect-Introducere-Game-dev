using System;
using UnityEngine;

public class FloatingTurret : BaseMovingEnemyController
{
    [HideInInspector]
    public bool mustPatrol = true;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    bool mustFlip = false;
    public LayerMask groundLayer;

    protected override void Start()
    {
        base.Start();
        mustPatrol = true;
    }

    protected override void EnemyAbility(Transform target)
    {
        base.EnemyAbility(target);
        if(mustPatrol)
        {
            Patrol();
        }
    }

    public void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }

    }

    private void Patrol()
    {
        if(mustFlip)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    protected new void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

}
