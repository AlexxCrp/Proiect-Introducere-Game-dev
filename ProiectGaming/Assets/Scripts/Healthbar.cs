using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private float _scale = 0.3f;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        //var healthbarTransform = base.transform;
        //healthbarTransform.localScale = Vector3.one * _scale;

        SetMaxHealth(1000);

    }

    public void SetMaxHealth(float value)
    {
        slider.maxValue = value;
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float value)
    {
        slider.value = value;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
