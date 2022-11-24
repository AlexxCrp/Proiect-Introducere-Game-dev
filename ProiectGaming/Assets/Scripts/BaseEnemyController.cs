using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    public float HP = 1000;
    public SpriteRenderer sprite;
    public float range;
    public GameObject gun;
    public Transform firePoint;
    public GameObject bullet;
    public float fireCooldown;
    public Animator animator;
    public float flashRedTime;

    float lastAttackTime = 0f;
    Vector2 direction;
    Transform target;

    void Update()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Vector2 targetPosition = target.position;
        direction = targetPosition - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);

        if (rayInfo)
        {
            EnemyAbility(target, animator);
            if(Time.time - lastAttackTime >= fireCooldown)
                Shoot();
        }
    }

    private void OnDrawGizmosSelected()
    {
        //used to see the range in scene view
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public virtual void EnemyAbility(Transform target, Animator animator)
    {


    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        lastAttackTime = Time.time;
    }

    //will be used by player bullets
    public void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine(FlashRed());
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashRedTime);
        sprite.color = Color.white;
    }
}
