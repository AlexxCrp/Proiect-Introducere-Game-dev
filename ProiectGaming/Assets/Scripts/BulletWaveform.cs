using Unity.VisualScripting;
using UnityEngine;

public class BulletWaveform : Bullet
{
    private static readonly float BaseFireRate = 2f;
    private static float _updatingFireRate = 2f;
    public BulletWaveform()
    {
        Damage = 10f;
        FireRate = _updatingFireRate;
        Speed =50f;
        CollisionAnimation = "WaveformCollisionAnimation";
    }

    public override void PassiveEffect()
    {
        if (_updatingFireRate >= 0.1f)
        {
            _updatingFireRate -= 0.05f;
            Debug.Log(_updatingFireRate);
            Debug.Log(FireRate);
        }
    }
}