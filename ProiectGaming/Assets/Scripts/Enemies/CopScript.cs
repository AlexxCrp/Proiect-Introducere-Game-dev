using UnityEngine;

public class CopScript : BaseMovingEnemyController
{
    public float minimumDistance = 1f;
    public Transform groundCheckPos;


    protected override void Start()
    {
        base.Start();
        walkSpeed = 7.0f;
    }

    protected override void EnemyAbility(Transform target)
    {
        base.EnemyAbility(target);

        bool isOutOfRange = range < Vector3.Distance(transform.position, target.position);
        animator.SetBool("isOutOfRange", isOutOfRange);
        if(isOutOfRange)
        {
            return;
        }

        bool isInMinRange = Vector2.Distance(target.position, transform.position) < minimumDistance;
        if (!isInMinRange)
        {
            transform.position += transform.right * walkSpeed * Time.deltaTime;
            animator.SetFloat("Speed", walkSpeed);
            animator.SetBool("isInMinRange", false);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            animator.SetBool("isInMinRange", true);
        }
    }
}
