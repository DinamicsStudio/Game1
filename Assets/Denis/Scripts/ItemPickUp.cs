using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickUp : MonoBehaviour
{
    public Transform OldParent;
    public Transform UpItem;
    public Transform ItemPos;
    public bool usable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            UpItem = other.GetComponent<Transform>();
            usable = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            UpItem = null;
            usable = false;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && usable)
        {
            PickUp(UpItem);
        }
        if(Input.GetKeyDown(KeyCode.Q) && UpItem!=null)
        {
            PickDown(UpItem);
        }
    }
    void PickUp(Transform item)
    {
        OldParent = item.parent;
        item.position = ItemPos.position;
        item.SetParent(transform);
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Collider>().enabled = false;

    }
    void PickDown(Transform item)
    {
        UpItem = null;
        item.SetParent(OldParent);
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Collider>().enabled = true;
    }
}
