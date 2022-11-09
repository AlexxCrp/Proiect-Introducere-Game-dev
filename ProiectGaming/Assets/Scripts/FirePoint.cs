using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ignore this class for now
public class FirePoint : MonoBehaviour
{
    public Transform turret;
    bool gunFacingRight = true;

    void Update()
    {
        if (turret.rotation.z < -90 && turret.rotation.z > -270 && !gunFacingRight)
        {
            transform.Rotate(0f, 0f, 90f);
            gunFacingRight = true;
        }
        if (turret.rotation.z < -270 && turret.rotation.z > -450 && gunFacingRight)
        {
            transform.Rotate(0f, 0f, 90f);
            gunFacingRight = false;
        }
    }
}
