using System;
using UnityEngine;

public class FloatingTurret : BaseMovingEnemyController
{
    [HideInInspector]
    public bool mustPatrol = true;
    public Transform groundCheckPos;
    bool mustFlip = false;
    public LayerMask groundLayer;
    private Collider2D collider;

    protected override void Start()
    {
        base.Start();
        mustPatrol = true;
        collider = GetComponent<Collider2D>();
    }

    protected override void EnemyAbility(Transform target)
    {
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
        if(mustFlip || collider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        transform.position += transform.right * walkSpeed * Time.deltaTime;
    }

    protected new void Flip()
    {
        mustPatrol = false;
        base.Flip();
        mustPatrol = true;
    }
}
