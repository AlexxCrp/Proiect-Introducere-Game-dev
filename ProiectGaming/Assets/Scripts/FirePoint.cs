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
        float z = turret.rotation.z;
        if(!gunFacingRight && z.InInterval(-270, -90, false, false))
        {
            transform.Rotate(0f, 0f, 90f);
            gunFacingRight = true;
        }
        if(gunFacingRight && z.InInterval(-450, -270, false, false))
        {
            transform.Rotate(0f, 0f, 90f);
            gunFacingRight = false;
        }
    }
}
