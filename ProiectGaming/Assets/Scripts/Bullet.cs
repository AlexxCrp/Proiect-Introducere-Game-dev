using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Bullet
{
    public float Damage { get; set; } = 100f;

    public float FireRate { get; set; } = 0.35f;

    public float Speed { get; set; } = 20f;

    public virtual void PassiveEffect()
    {
    }

    public virtual void ActiveEffect()
    {
    }
}