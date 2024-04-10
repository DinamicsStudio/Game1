using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventoryObject; //для вкл/выкл инвентаря
    private bool isOn;
    private void Start()
    {
        isOn = false;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            OnInventoryClick();
        }
    }
    public void OnInventoryClick()
    {
        if (isOn == false)
        {
            isOn = true;
            inventoryObject.SetActive(true);
        }
        else if (isOn == true) 
        {
            isOn = false;
            inventoryObject.SetActive(false);
        }
    }

}
