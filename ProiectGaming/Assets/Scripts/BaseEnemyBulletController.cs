using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBulletController : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 100;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public virtual void BulletSpecialEffect()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
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
