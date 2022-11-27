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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
        Instantiate(bullet, firePoint3.position, firePoint3.rotation);
        lastAttackTime = Time.time;
    }
}
