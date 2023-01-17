using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBulletController : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 100;
    public float lifetime = 3f;
    public Rigidbody2D rb;
    private float bulletLifetimer;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    
    void Update()
    {
        bulletLifetimer += Time.deltaTime;

        if (bulletLifetimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public virtual void BulletSpecialEffect()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject);
            return;
        }

        if (!collider.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        PlayerManager character = collider.GetComponent<PlayerManager>();
        if (character != null)
        {
            BulletSpecialEffect();
            character.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
