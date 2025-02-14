using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class SelectionManager : MonoBehaviour
{

    public GameObject InteractionInfo;
    TextMeshProUGUI interaction_text;
    public GameObject pistol2;
    public GameObject player;
    public GameObject Door;
    private void Start()
    {
        interaction_text = InteractionInfo.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            
            if (selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange)
            {
                InteractionInfo.SetActive(true);
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (selectionTransform.GetComponent<InteractableObject>()
                        .GetItemName().Contains("Ammo box") )
                    {
                        pistol2.GetComponent<Shooting>().RefillBullets(30);
                        Destroy(selectionTransform.gameObject);
                    }
                    else if (selectionTransform.GetComponent<InteractableObject>().GetItemName()
                             .Contains("First Aid Kit"))
                    {
                        
                        if (player.GetComponent<PlayerHealth>().slots < 6)
                        {
                            player.GetComponent<PlayerHealth>().FillAidSlots();
                            Destroy(selectionTransform.gameObject);
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    
                    hit.transform.GetComponent<DoorScript>().OpenDoor();
                }
            }
            else
            {
                InteractionInfo.SetActive(false);
            }

        }

        else

        {
            InteractionInfo.SetActive(false);
        }

    }
}