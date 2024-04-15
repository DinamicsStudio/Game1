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
   

}
