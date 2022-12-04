using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public enum PickupType
    {
        WaveformPickup,
        BoltPickup,
        ChargedPickup,
        CrossedPickup
    }
    
    private void Start()
    {
        StartCoroutine(PickupFloatingAnimation());
    }

    private IEnumerator PickupFloatingAnimation()
    {
        while (true)
        {
            transform.position = new Vector3(0, Mathf.Sin(Time.time) * 0.5f, 0);
            yield return null;
        }
    }

    public static void PickUp(GameObject pickup)
    {
        Enum.TryParse(pickup.name, out PickupType pickupType);
        
        switch (pickupType)
        {
            default:
            case PickupType.CrossedPickup:
                BulletManager.Instance.bulletType = BulletManager.BulletType.Crossed;
                break;
            case PickupType.BoltPickup:
                BulletManager.Instance.bulletType = BulletManager.BulletType.Bolt;
                break;
            case PickupType.ChargedPickup:
                BulletManager.Instance.bulletType = BulletManager.BulletType.Charged;
                break;
            case PickupType.WaveformPickup:
                BulletManager.Instance.bulletType = BulletManager.BulletType.Waveform;
                break;
        }
        
        Destroy(pickup);
    }
}
