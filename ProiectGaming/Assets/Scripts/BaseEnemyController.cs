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

    protected float lastAttackTime = 0f;
    Vector2 direction;
    Transform target;
    int layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Player");
    }
    void Update()
    {
        //cast ray to player if in range of enemy
        //while ray is cast shoot
        //there are easier methods to just shoot when player is in range, using colliders,
        //but we'll be keeping this code because some turrets will aim at players
        //and in those cases a ray is a good solution

        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Vector2 targetPosition = target.position;
        direction = targetPosition - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range, layerMask);

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

    public virtual void Shoot()
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

        Debug.Log("Enemy took damage: " + damage);
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashRedTime);
        sprite.color = Color.white;
    }
}
