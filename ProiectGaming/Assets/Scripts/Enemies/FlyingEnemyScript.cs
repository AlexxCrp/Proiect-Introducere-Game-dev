using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyScript : BaseEnemyController
{
    public float speed = 10.0f;
    public float minimumDistance = 1f;

    protected override void EnemyAbility(Transform target)
    {
        firePoint.transform.right = target.position - transform.position;

        var distance = Vector2.Distance(target.position, transform.position);
        if(distance <= minimumDistance)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
