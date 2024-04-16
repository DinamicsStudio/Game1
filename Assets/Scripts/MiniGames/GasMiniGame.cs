using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GasMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private float _distanceForDrag;
    //public Transform pan;
    //public float maxDistanceFromPan; //от сковородки до мяса
    //public float fryingTime; //время жарки
    private bool _usable;
    private bool inGame;
    private bool isFrying = false;
    [SerializeField] private Inventory _inventory;

    private void Update()
    {
        if (Array.IndexOf(_inventory.ItemID, 1) != -1 && Input.GetKeyDown(KeyCode.E) && _usable)
        {
            if(!isFrying) _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)] = 0;
            _usable = false;
            inGame = true;
            Player.canmove = false;
            _miniGameUI.SetActive(true);

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            inGame = false;
            Player.canmove = true;
            _miniGameUI.SetActive(false);
        }
    }
    public void Draging(Transform obj)
    {
        if (Vector3.Distance(obj.position, Input.mousePosition) <= _distanceForDrag)
        {
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(Transform obj)
    {
        /*
        НАПИСАТЬ НОРМ, ЭТО ХУЙНЯ КАК БУДТО
        float distance = Vector3.Distance(transform.position, pan.position);
        if (distance < maxDistanceFromPan)
        {
            isFrying = true
            Debug.Log("Meat is ready!");
            fryingTime -= Time.deltaTime;
            if (fryingTime <= 0)
            {
                inGame = false;
                Player.canmove = true;
                _miniGameUI.SetActive(false);
                isFrying = false
       
            }
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _usable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _usable = false;
        }
    }
}
