using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
}