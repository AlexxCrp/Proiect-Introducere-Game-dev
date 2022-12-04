using UnityEngine;

public class BulletCharged : Bullet
{
    public BulletCharged()
    {
        Damage = 100f;
        FireRate = 1f;
        Speed = 10f;
    }

    public override void PassiveEffect(Transform firePoint)
    {
        Quaternion upperRotation = firePoint.rotation * Quaternion.Euler(0, 0, 30);
        Quaternion lowerRotation = firePoint.rotation * Quaternion.Euler(0, 0, -30);
        Object prefab = BulletManager.Instance.GetPrefab();
        BulletManager.Instantiate(prefab, firePoint.position, upperRotation);
        BulletManager.Instantiate(prefab, firePoint.position, lowerRotation);
    }
}