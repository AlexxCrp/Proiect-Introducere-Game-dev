using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletController : MonoBehaviour
{
    [SerializeField] private ShooterBehavior shooter;
    public Rigidbody2D _rb;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * shooter.getCurrentBullet().GetSpeed();
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
        if (enemy != null)
        {
            BulletSpecialEffect();
            enemy.TakeDamage(shooter.getCurrentBullet().GetDamage());
        }

        Destroy(gameObject);
    }
}