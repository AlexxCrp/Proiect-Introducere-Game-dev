using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovingEnemyController : BaseEnemyController
{
    protected float walkSpeed = 2.4f;
    protected bool facingRight = true;

    // Update is called once per frame
    protected override void EnemyAbility(Transform target)
    {
        if (facingRight && targetOnLeft(target))
        {
            Flip();
        }
        else if (!facingRight && targetOnRight(target))
        {
            Flip();
        }
    }

    protected void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
    }

    protected bool targetOnLeft(Transform target) => target.position.x < transform.position.x;
    protected bool targetOnRight(Transform target) => target.position.x > transform.position.x;
}
