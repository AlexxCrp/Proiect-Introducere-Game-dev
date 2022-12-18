using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofTurretScript : BaseEnemyController
{
    public Transform firePoint2;
    public Transform firePoint3;

    // Start is called before the first frame update
    public override void Shoot()
    {
        InstantiateBullet(firePoint);
        InstantiateBullet(firePoint2);
        InstantiateBullet(firePoint3);
        lastAttackTime = Time.time;
    }

    private void InstantiateBullet(Transform firePoint) => Instantiate(bullet, firePoint.position, firePoint.rotation);

}
