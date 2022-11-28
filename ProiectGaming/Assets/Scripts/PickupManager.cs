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
}
