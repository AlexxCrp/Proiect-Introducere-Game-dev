using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletWaveform : Bullet
{
    private static readonly float BaseFireRate = 1.5f;
    private static float _updatingFireRate = BaseFireRate;
    public BulletWaveform()
    {
        Damage = 10f;
        FireRate = _updatingFireRate;
        Speed = 50f;
    }

    public override void PassiveEffect()
    {
        if (_updatingFireRate >= 1f)
        {
            _updatingFireRate -= 0.1f;
        }
        else if (_updatingFireRate >= 0.5f)
        {
            _updatingFireRate -= 0.05f;
        } else if (_updatingFireRate >= 0.1f)
        {
            _updatingFireRate -= 0.01f;
        }
        else
        {
            _updatingFireRate = BaseFireRate;
        }
    }
}