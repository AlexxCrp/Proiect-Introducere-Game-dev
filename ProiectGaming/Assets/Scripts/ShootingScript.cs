using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform firePoint;
    public Animator animator;

    bool isPressed = false;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isPressed = true;
        }

        if (isPressed & canShoot)
        {
            StartCoroutine(Shoot());
            animator.SetBool("isShooting", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isPressed = false;
            animator.SetBool("isShooting", false);
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(BulletManager.Instance.GetPrefab(), firePoint.position, firePoint.rotation);
        BulletManager.Instance.GetBullet().PassiveEffect(firePoint);
        yield return new WaitForSecondsRealtime(BulletManager.Instance.GetBullet().FireRate);
        canShoot = true;
    }
}