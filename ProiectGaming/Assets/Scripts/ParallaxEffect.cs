using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject mainCamera;
    public float parallaxStrength;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = (mainCamera.transform.position.x * parallaxStrength);
        float temp = (mainCamera.transform.position.x * (1 - parallaxStrength));
        
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}