using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopScript : BaseEnemyController
{
    public float speed = 10.0f;
    public float minimumDistance = 1f;
    private bool facingRight = true;
    public override void EnemyAbility(Transform target, Animator animator)
    {
        if (Vector3.Distance(transform.position, target.position) > range)
        {
            animator.SetBool("isOutOfRange", true);
        }
        else
        {
            animator.SetBool("isOutOfRange", false);

        }
        if (facingRight && target.position.x < transform.position.x)
        {
            facingRight = false;
            transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        }
        if (!facingRight && target.position.x > transform.position.x)
        {
            facingRight = true;
            transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        }
        
        if (Vector2.Distance(target.position, transform.position) > minimumDistance)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            animator.SetFloat("Speed", 10);
            animator.SetBool("isInMinRange", false);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            animator.SetBool("isInMinRange", true);
        }
    }
}
