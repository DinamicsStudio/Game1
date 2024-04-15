using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _slotNumber;
    [SerializeField] private Inventory inventory;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (_inventory.ObjCountInSlot[_slotNumber]==0)
        {
            _inventory.SlotStack[_slotNumber] = 1;
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
            inventory.CountInSlotText[_slotNumber].text = inventory.ObjCountInSlot[_slotNumber].ToString();
            child.GetComponent<Drop>().SpawnDroppedItem();
            if (_inventory.ObjCountInSlot[_slotNumber] == 0)
                Destroy(child.gameObject);
        }
    }
}
