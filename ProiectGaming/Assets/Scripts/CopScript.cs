using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopScript : BaseEnemyController
{
    public float speed = 10.0f;
    public float minimumDistance = 1f;
   public override void EnemyAbility(Transform target, Animator animator)
   {
        Vector3 displacement = target.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(target.position, transform.position) > 5.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
