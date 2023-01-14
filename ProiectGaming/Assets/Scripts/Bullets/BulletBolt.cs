using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBolt : Bullet
{
    public BulletBolt()
    {
        Damage = 50f;
        FireRate = 1f;
        Speed = 10f;
    }

    private const float EmpDuration = 3f;

    public override void OnHitEffect(BaseEnemyController enemy)
    {
        BulletManager.Instance.StartCoroutine(EMP(enemy));
    }

    private IEnumerator EMP(BaseEnemyController enemy)
    {
        enemy.Disable();
        yield return new WaitForSecondsRealtime(EmpDuration);
        enemy.Enable();
    }
}