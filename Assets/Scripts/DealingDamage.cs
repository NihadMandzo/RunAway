using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().DealDamage();
        }
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log(other.gameObject.tag);
    //     // if (other.gameObject.CompareTag("Player"))
    //     // {
    //     //     other.transform.parent.gameObject.GetComponent<PlayerHealth>().DealDamage();
    //     // }
    // }
}
