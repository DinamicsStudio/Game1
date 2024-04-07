using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            PickUp(collision.gameObject.transform);
        }
    }

    void PickUp(Transform item)
    {
        item.SetParent(transform);
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Collider>().enabled = false;
    }
}
