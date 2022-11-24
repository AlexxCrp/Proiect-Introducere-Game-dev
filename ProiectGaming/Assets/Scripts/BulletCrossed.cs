using System.Collections;
using UnityEngine;

public class BulletCrossed : Bullet
{
    private static readonly float PoisonDamage = 10f;

    private static readonly int MaxPoisonStacks = 5;
    private static readonly int MaxPoisonTicks = 5;
    private static readonly float TimeBetweenTicks = 1f;

    private static int _currentPoisonStacks;


    public BulletCrossed()
    {
        Damage = 50f;
        FireRate = 0.5f;
        Speed = 10f;
    }

    public override void OnHitEffect(BaseEnemyController enemy)
    {
        Debug.Log("Applying poison");
        ApplyPoisonStack(enemy);
    }

    private void ApplyPoisonStack(BaseEnemyController enemy)
    {
        _currentPoisonStacks += 1;
        int currentPoisonTicks = 0;
        if (_currentPoisonStacks < MaxPoisonStacks)
        {
            BulletManager.Instance.StartCoroutine(DealPoisonTick(enemy, currentPoisonTicks));
        }

        _currentPoisonStacks -= 1;
    }

    private IEnumerator DealPoisonTick(BaseEnemyController enemy, int currentPoisonTicks)
    {
        Debug.Log("In poison tick");

        while (currentPoisonTicks < MaxPoisonTicks)
        {
            if (enemy == null)
            {
                yield break;
            }
            enemy.TakeDamage(PoisonDamage);
            currentPoisonTicks += 1;
            Debug.Log("Ticks: " + currentPoisonTicks);
            yield return new WaitForSecondsRealtime(TimeBetweenTicks);
        }

    }
}