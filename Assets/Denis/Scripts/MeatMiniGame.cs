﻿using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class MeatMiniGame : MonoBehaviour
{
    public event Action MeatUpdate;
    public int meatCountInThis = 0;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _miniGameUI;

    [Space]
    [Space]
    [Space]

    [SerializeField] private PickUp _pickUp;
    [SerializeField] private TMP_Text _meatPiecesText;
    [SerializeField] private float _distance;
    [SerializeField] private GameObject[] _polosi;

    [Space]
    [Space]
    [Space]

    [SerializeField] private GameObject _meatImage;
    [SerializeField] private GameObject[] _meats;
    [SerializeField] private Animator _anim2;
    [SerializeField] private GameObject _meatTextObject; //in game

    private bool _usable;
    private bool InGame;
    [SerializeField]private int i;
    public void Draging(Transform obj)
    {
        //Debug.Log(1);
        if (Vector3.Distance(obj.position, Input.mousePosition) <= _distance)
        {
            //Debug.Log(Input.mousePosition);
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(Transform obj)
    {
        if (3 - Mathf.Round(Mathf.Abs(obj.position.x - _polosi[i].GetComponent<Transform>().position.x) / 30)>=1)
        {
            _polosi[i].SetActive(false);
            _meats[i].SetActive(false);
            meatCountInThis += Convert.ToInt32(3 - Mathf.Round(Mathf.Abs(obj.position.x - _polosi[i].GetComponent<Transform>().position.x) / 30));
            //_anim2.SetTrigger("trig");
            i++;
            
            if(i< _polosi.Length)
            {
                _polosi[i].SetActive(true);
            }
            else
            {
           
                MeatUpdate.Invoke();
                InGame = false;
                Player.canmove = true;
                for(int j=0;j<meatCountInThis;j++)
                {
                    Debug.Log(_polosi.Length);
                    _pickUp.PickUping(12, 1, _inventory, _meatImage,false);
                }
                meatCountInThis = i = 0;
                _miniGameUI.SetActive(false);
                _meatTextObject.GetComponent<TextMeshProUGUI>().enabled = true;
                _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 0)]--;
                /*Debug.Log(Array.IndexOf(_inventory.ItemID, 0));
                Debug.Log(Array.IndexOf(_inventory.ItemID, 0));
                Debug.Log(Array.IndexOf(_inventory.ItemID, 0));
                Debug.Log(Array.IndexOf(_inventory.ItemID, 0));
                Debug.Log(Array.IndexOf(_inventory.ItemID, 0));
                Debug.Log(Array.IndexOf(_inventory.ItemID, 0));
                Debug.Log(Array.IndexOf(_inventory.ItemID, 0));*/
            }
        }
    }
    private void Update()
    {
        if(Array.IndexOf(_inventory.ItemID, 0)!=-1 && Input.GetKeyDown(KeyCode.E) && _usable) 
        {
            for(int i=0;i<_meats.Length;i++)
            {
                _meats[i].SetActive(true);
            }
            _polosi[0].SetActive(true);
            InGame = true;
            Player.canmove = false;
            _miniGameUI.SetActive(true);
            _meatTextObject.GetComponent<TextMeshProUGUI>().enabled = false;
            
        }
        if(Input.GetKeyDown(KeyCode.Escape) && InGame)
        {
            InGame = false;
            Player.canmove = true;
            _miniGameUI.SetActive(false);
            _meatTextObject.SetActive(true);
        }
        _meatPiecesText.text = "Pieces of meat: " + meatCountInThis;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _usable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _usable = false;
            _meatTextObject.SetActive(true);
        }
    }
}
