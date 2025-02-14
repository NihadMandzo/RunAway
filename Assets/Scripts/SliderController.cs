using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    float healthadd = 0.00f;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        healthadd = 16;
        slider.value = healthadd;
    }

    public void UpdateHealth(float damage)
    {
        healthadd+=damage;
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthadd;
        
    }
}
