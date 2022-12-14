using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Object = UnityEngine.Object;

public class BulletManager: MonoBehaviour
{
    public enum BulletType
    {
        Basic,
        Waveform,
        Crossed,
        Charged,
        Bolt
    }

    public BulletType bulletType;

    public static BulletManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    public Object BasicPrefab;
    public Object WaveformPrefab;
    public Object CrossedPrefab;
    public Object ChargedPrefab;
    public Object BoltPrefab;

    public Bullet GetBullet()
    {
        switch (bulletType)
        {
            default:
            case BulletType.Basic:
                return new Bullet();
            case BulletType.Waveform:
                return new BulletWaveform();
            case BulletType.Crossed:
                return new BulletCrossed();
            case BulletType.Charged:
                return new BulletCharged();
            case BulletType.Bolt:
                return new BulletBolt();
        }
    }

    public Object GetPrefab()
    {
        switch (bulletType)
        {
            default:
            case BulletType.Basic: return BasicPrefab;   
            case BulletType.Waveform: return WaveformPrefab;
            case BulletType.Crossed: return CrossedPrefab;
            case BulletType.Charged: return ChargedPrefab;
            case BulletType.Bolt: return BoltPrefab;
        }
    }
}