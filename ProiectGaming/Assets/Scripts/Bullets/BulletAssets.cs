using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAssets : MonoBehaviour
{
    public static BulletAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Object BasicPref;

    public BulletManager.BulletType getBullet(int index)
    {
        switch (index)
        {
            default: return BulletManager.BulletType.Basic;
        }
    }
}