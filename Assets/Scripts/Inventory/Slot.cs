using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _slotNumber;
    private void Update()
    {
        if (_inventory.ObjCountInSlot[_slotNumber]==0)
        {

        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Drop>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
