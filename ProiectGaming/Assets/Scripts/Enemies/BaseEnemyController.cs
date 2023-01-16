using System.Collections;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    public float HP = 1000;
    public SpriteRenderer sprite;
    public float range;
    public GameObject gun;
    public Transform firePoint;
    public GameObject bullet;
    public GameObject heart;
    public float fireCooldown;
    public Animator animator;
    public float flashRedTime;
    bool isDead = false;

    protected float lastAttackTime = 0f;
    Vector2 direction;
    Transform target;
    int layerMask;
    private bool isDisabled;

    protected virtual void Start()
    {
        layerMask = LayerMask.GetMask("Player");
    }

    protected virtual void Update()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        direction = target.position - transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range, layerMask);

        if (!rayInfo)
        {
            return;
        }

        EnemyAbility(target);

        bool canShoot = !isDisabled && (Time.time - lastAttackTime >= fireCooldown);
        if (canShoot)
        {
            Shoot();
        }
        if (isDead)
        {
            Score.IncrementScore();
            SpawnHeart();
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //used to see the range in scene view
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected virtual void EnemyAbility(Transform target)
    { 

    }

    public virtual void Shoot()
    {
        Instantiate(bullet, firePoint.position, Quaternion.Euler(0, firePoint.rotation.eulerAngles.y, firePoint.rotation.eulerAngles.z));
        lastAttackTime = Time.time;
    }

    //will be used by player bullets
    public void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine(FlashRed());
        if (HP <= 0)
        {
            StartCoroutine(Die());
        }
        Debug.Log(string.Format("Enemy took damage: {0}", damage));
    }

    private void SpawnHeart()
    {
        var randVal = Random.Range(0, 10);
        if(randVal <= 3)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashRedTime);
        sprite.color = Color.white;
    }

    public IEnumerator Die()
    {
        animator.Play("Explosion");
        yield return new WaitForSeconds(1);
        isDead = true;
    }

    public void Disable()
    {
        isDisabled = true;
    }

    public void Enable()
    {
        isDisabled = false;
    }
}