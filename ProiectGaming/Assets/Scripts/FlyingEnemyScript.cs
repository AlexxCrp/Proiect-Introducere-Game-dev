using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyScript : BaseEnemyController
{
    public float speed = 10.0f;
    public float minimumDistance = 1f;
    public override void EnemyAbility(Transform target, Animator animator)
    {
        firePoint.transform.right = target.position - transform.position;
        if (Vector2.Distance(target.position, transform.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}