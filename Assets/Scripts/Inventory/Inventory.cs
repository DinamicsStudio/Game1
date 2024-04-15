using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] IsFull;
    public int[] ItemID;
    public int[] SlotStack;
    public int[] ObjCountInSlot;
    public TMP_Text[] CountInSlotText;

    public GameObject[] _slots;
    //[SerializeField] private GameObject _inventoryObject; //для вкл/выкл инвентаря
    //private bool _isOn;
    private void Start()
    {
        //_isOn = false;
    }
    private void Update()
    { 
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            //OnInventoryClick();
        }
    }
    /*
    public void OnInventoryClick()
    {
        if (_isOn == false)
        {
            _isOn = true;
            _inventoryObject.SetActive(true);
        }
        else if (_isOn == true) 
        {
            _isOn = false;
            _inventoryObject.SetActive(false);
        }
    }
    */

}
