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
        Basic
    }

    public BulletType bulletType;

    public static BulletManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    public Object BasicPrefab;

    public Bullet GetBullet()
    {
        switch (bulletType)
        {
            default:
            case BulletType.Basic:
                return new Bullet();
        }
    }

    public Object GetPrefab()
    {
        switch (bulletType)
        {
            default:
            case BulletType.Basic: return BasicPrefab;    
        }
    }
}