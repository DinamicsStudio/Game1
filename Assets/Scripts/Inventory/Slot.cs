using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int slotNumber; 

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if(transform.childCount <= 0) //проверка пустой ли слот
        {
            inventory.isFull[slotNumber] = false;
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.name.Contains("Meat"))
            {
                PickUp.isPicked = true;
            }
            PickUp.isPicked = false;
            child.GetComponent<Drop>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
