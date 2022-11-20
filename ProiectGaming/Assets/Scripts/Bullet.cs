using System;

public class Bullet
{
    public float Damage { get; set; } = 100f;

    public float FireRate { get; set; } = 0.35f;

    public float Speed { get; set; } = 20f;
    public String CollisionAnimation = "BasicCollisionAnimation";

    // Passive effect occurs on shoot
    public virtual void PassiveEffect()
    {
    }

    // Active effect occurs on active skill key press
    public virtual void ActiveEffect()
    {
    }
    
    public virtual void OnHitEffect()
    {
    }
}