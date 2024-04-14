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
    private bool _usable;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null )
        {
            _usable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _usable = false;
    }

    private void Update()
    {
        if(_usable && Input.GetKeyDown(KeyCode.E))
        {
            PickUping(_maxInStack,_iD,_inventory,ImageInInventory,true);
        }
    }
    
    public void PickUping(int maxInStack,int iD,Inventory inventory,GameObject imageInInventory, bool del)
    {
        for (int i = 0; i < _inventory._slots.Length; i++)
        {
            if ((_inventory.ItemID[i] == _iD && _inventory.SlotStack[i] > _inventory.ObjCountInSlot[i]))
            {
                _inventory.ItemID[i] = iD;
                _inventory.SlotStack[i] = maxInStack;
                _inventory.ObjCountInSlot[i]++;
                //Instantiate(ImageInInventory, _inventory._slots[i].transform);
                if(del)Destroy(gameObject);
                break;
            }
            if (_inventory.ItemID[i] == -1)
            {
                _inventory.ItemID[i] = iD;
                _inventory.SlotStack[i] = maxInStack;
                _inventory.ObjCountInSlot[i]++;
                Instantiate(imageInInventory, inventory._slots[i].transform);
                if(del)Destroy(gameObject);
                break;
            }
        }
    }
}
