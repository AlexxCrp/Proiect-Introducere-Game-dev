using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Bullet
{
    public enum BulletType
    {
        Basic
    }

    private Dictionary<BulletType, Dictionary<String, float>> _typeToProperties = new()
    {
        {
            BulletType.Basic,
            new Dictionary<string, float> { { "fireRate", 0.35f }, { "damage", 100f }, { "speed", 20f } }
        }
    };

    public BulletType bulletType;

    public Object GetPrefab()
    {
        switch (bulletType)
        {
            default: return BulletAssets.Instance.BasicPref;
        }
    }

    public float GetDamage()
    {
        return _typeToProperties[bulletType]["damage"];
    }

    public float GetFireRate()
    {
        return _typeToProperties[bulletType]["fireRate"];
    }

    public float GetSpeed()
    {
        return _typeToProperties[bulletType]["speed"];
    }
}