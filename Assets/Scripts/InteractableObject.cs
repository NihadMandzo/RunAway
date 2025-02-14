using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{

    public bool playerInRange;
    public string ItemName;
    private void Start()
    {
        playerInRange = false;
    }

    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            
            playerInRange = true;
        }
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log(other);
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         playerInRange = true;
    //     }
    // }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
