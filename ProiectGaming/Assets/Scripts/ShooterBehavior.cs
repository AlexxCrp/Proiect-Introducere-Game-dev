using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePos;
    public PlayerManager _player;
    public float speed = 15f;
    private bool gunFacingRight = true;
    public GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (_player.facingRight)
        {
            direction = _mousePos - transform.position;
        }
        else
        {
            direction = -(_mousePos - transform.position);
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);


        if (_player.facingRight && !gunFacingRight)
        {
            firePoint.transform.Rotate(0f, 180f, 0f);
            gunFacingRight = true;
        }

        if (!_player.facingRight && gunFacingRight)
        {
            firePoint.transform.Rotate(0f, 180f, 0f);
            gunFacingRight = false;
        }
    }
}