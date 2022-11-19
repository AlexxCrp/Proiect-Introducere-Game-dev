using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletController : MonoBehaviour
{
    public float damage = 50;
    public float speed = 20f;

    public Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * speed;
    }

    public virtual void BulletSpecialEffect()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            return;
        }

        BaseEnemyController enemy = collider.GetComponent<BaseEnemyController>();
        Debug.Log("Enemy: " + enemy.HP);
        if (enemy != null)
        {
            BulletSpecialEffect();
            enemy.TakeDamage(damage);
            Debug.Log(enemy.HP);
        }

        Destroy(gameObject);
    }
}