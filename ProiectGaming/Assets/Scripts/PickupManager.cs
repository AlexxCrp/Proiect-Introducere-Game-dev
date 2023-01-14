using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private float initialY;
    public enum PickupType
    {
        WaveformPickup,
        BoltPickup,
        ChargedPickup,
        CrossedPickup
    }
    
    private void Start()
    {
        initialY = transform.position.y;
        StartCoroutine(PickupFloatingAnimation());
        Debug.Log(initialY);
    }

    private IEnumerator PickupFloatingAnimation()
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x, initialY + Mathf.Sin(Time.time) * 0.5f, 0);
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
