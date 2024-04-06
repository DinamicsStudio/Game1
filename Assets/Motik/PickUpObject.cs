using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public float pickUpRange = 3f;
    private Transform player;
    void Start()
    {
        player = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if

            (Physics.Raycast(player.position, player.forward, out hit, pickUpRange))
            {
                if (hit.transform.CompareTag("Item"))
                {
                    PickUp(hit.transform);
                }
            }
            
        }
    }
    void PickUp(Transform item)
    {
        item.SetParent(player);

        item.GetComponent<Rigidbody>().isKinematic = true;

        item.GetComponent<Collider>().enabled = false;
    }

}      
