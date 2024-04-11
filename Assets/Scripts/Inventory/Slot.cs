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
            _inventory.ItemID[_slotNumber] = -1;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            _inventory.ObjCountInSlot[_slotNumber]--;
            child.GetComponent<Drop>().SpawnDroppedItem();
            if (_inventory.ObjCountInSlot[_slotNumber] == 0)
                Destroy(child.gameObject);
        }
    }
}
