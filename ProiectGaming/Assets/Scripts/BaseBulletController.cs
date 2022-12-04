using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletController : MonoBehaviour
{
    public Rigidbody2D _rb;
    private Bullet _bullet;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        _bullet = BulletManager.Instance.GetBullet();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * _bullet.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        BaseEnemyController enemy = collider.GetComponent<BaseEnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(_bullet.Damage);
            _bullet.OnHitEffect(enemy);
            animator.SetBool("Hit", true);
            _rb.velocity = Vector2.zero;
        }
        
        
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}