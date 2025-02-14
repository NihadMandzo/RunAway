using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Bullet : MonoBehaviour
{
    public int headDamage;
    public int bodyDamage;
    //public EnemyScript enemyScript;
    // public void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Head"))
    //     {
    //     Debug.Log("Ode glava");
    //         enemyScript.TakeDamage(headDamage);
    //         Destroy(gameObject);
    //     }
    //     else if (other.gameObject.CompareTag("Body"))
    //     {
    //     Debug.Log("Ode tijelo");
    //         enemyScript.TakeDamage(bodyDamage);
    //         Destroy(gameObject);
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Head"))
    //     {
    //         GameObject zombie = other.transform.parent.gameObject;
    //         zombie.GetComponent<EnemyScript>().TakeDamage(headDamage);
    //         Debug.Log("Ode glava");
    //         Destroy(gameObject);
    //     }
    //     else if (other.gameObject.CompareTag("Body"))
    //     {
    //         GameObject zombie = other.transform.parent.gameObject;
    //         zombie.GetComponent<EnemyScript>().TakeDamage(bodyDamage);
    //         Debug.Log("Ode tijelo");
    //         Destroy(gameObject);
    //     }
    // }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var PartOfBody = hit.collider.tag;
                if (PartOfBody=="Head")
                {
                    GameObject zombie = hit.transform.gameObject;
                    zombie.GetComponent<EnemyScript>().TakeDamage(2);
                }
                else if(PartOfBody=="Body")
                {
                    GameObject zombie = hit.transform.gameObject;
                    zombie.GetComponent<EnemyScript>().TakeDamage(1);
                }

            }
        }
    }
}