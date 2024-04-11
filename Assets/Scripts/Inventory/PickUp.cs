using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{
    public GameObject ImageInInventory;
    [SerializeField] private int _iD;
    [SerializeField] private int _maxInStack;

    [SerializeField] private Inventory _inventory;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>()!=null)
        {
            for (int i = 0; i < _inventory._slots.Length; i++)
            {
                if ((_inventory.ItemID[i]==_iD && _inventory.SlotStack[i] > _inventory.ObjCountInSlot[i]))
                {
                    _inventory.ItemID[i] = _iD;
                    _inventory.SlotStack[i] = _maxInStack;
                    _inventory.ObjCountInSlot[i]++;
                    Instantiate(ImageInInventory, _inventory._slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
                if(_inventory.ItemID[i] == -1)
                {

                    _inventory.ItemID[i] = _iD;
                    _inventory.SlotStack[i] = _maxInStack;
                    _inventory.ObjCountInSlot[i]++;
                    Instantiate(ImageInInventory, _inventory._slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }

    }
}
