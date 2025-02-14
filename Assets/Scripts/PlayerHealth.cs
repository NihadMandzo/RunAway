using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 20;
    float currentHealth = 16;
    public GameObject image;
    public int slots=0;
    public TextMeshProUGUI FAKtext;
    public GameObject HealthSlider;

    public Slider slider;
    public GameObject HealingTHINGy;
    public float fillSpeed = 0.07f;

    private bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Heal()
    {
        
        if (slots > 0)
        {
            HealthSlider.GetComponent<SliderController>().UpdateHealth(2f);
            currentHealth += 2f;
            slots--;
        }
        HealingTHINGy.SetActive(false);
    }
    // Update is called once per frame

    public void FillAidSlots()
    {
        if (slots<5)
        {
        slots++;
        }
    }
    void Update()
    {
        FAKtext.text = slots.ToString() + "/5";
        if (Input.GetKey(KeyCode.F) && slots<6 && slots>0)
        {
            isPressed = true;
            HealingTHINGy.SetActive(true);
            if (isPressed && slider.value<slider.maxValue)
            {
                slider.value += fillSpeed + Time.deltaTime;
            }

            if (slider.value>=slider.maxValue)
            {
            Heal();
            }
        }
        else
        {
            slider.value = 0;
            isPressed = false;
            HealingTHINGy.SetActive(false);
        }
        if (currentHealth < 1)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);

        }
        
    }

    public  void DealDamage()
    {
        Debug.Log(currentHealth);
        if (currentHealth<=0)
        {
            SceneManager.LoadSceneAsync("Displays/EndMenu");
        }
        
        currentHealth-=0.025f;
        HealthSlider.GetComponent<SliderController>().UpdateHealth(-0.025f);
        //image.SetActive(false);
    }

    // private void OnCollisionStay(Collision other)
    // {
    //     Debug.Log(other.gameObject.tag);
    //     if (other.gameObject.CompareTag("Target"))
    //     {
    //         DealDamage();
    //         Debug.Log(currentHealth);
    //     }
    //     
    // }

    
}
