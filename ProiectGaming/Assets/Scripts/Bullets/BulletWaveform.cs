using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletWaveform : Bullet
{
    private static readonly float BaseFireRate = 0.5f;
    private static readonly float MediumFireRate = 0.25f;
    private static readonly float FastFireRate = 0.15f;
    private static readonly float ReallyFastFireRate = 0.05f;
    
    private static float _updatingFireRate = BaseFireRate;

    public BulletWaveform()
    {
        Damage = 50f;
        FireRate = _updatingFireRate;
        Speed = 30f;
    }

    public override void PassiveEffect(Transform firePoint)
    {
        if (_updatingFireRate >= MediumFireRate)
        {
            _updatingFireRate -= 0.1f;
        }
        else if (_updatingFireRate >= FastFireRate)
        {
            _updatingFireRate -= 0.05f;
        }
        else if (_updatingFireRate >= ReallyFastFireRate)
        {
            _updatingFireRate -= 0.005f;
        }
        else
        {
            _updatingFireRate = BaseFireRate;
        }
    }
}