using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GasMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private float _distanceForDrag;
    [SerializeField] private Transform pan;
    [SerializeField] private float maxDistanceFromPan; //от сковородки до мяса
    [SerializeField] private float fryingTime; //время жарки
    private bool _usable;
    private bool inGame;
    bool isFrying = false;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PickUp _pickUp;
    [SerializeField] private RectTransform dragingMeat; //для указа позиции
    [SerializeField] private RectTransform meatStartPos;
    [SerializeField] private TMP_Text fryText;

    private int meatCount;
    public GameObject ReadyMeatImage;

    public void Draging(Transform obj)
    {
        if (Vector3.Distance(obj.position, Input.mousePosition) <= _distanceForDrag)
        {
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(Transform obj)
    {
        float distance = Vector3.Distance(obj.position, pan.position);
        if (distance <= maxDistanceFromPan)
        {
            isFrying = true;
            fryText.gameObject.SetActive(true);
            meatCount = _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)];
            _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)] = 0;

        }
    }
    private void Update()
    {
        if(isFrying)
        {
            fryingTime -= Time.deltaTime;
            fryText.text = $"Wait, meat is frying. Left {Convert.ToInt32(fryingTime)} seconds";
        }
        if (fryingTime <= 0)
        {
            fryingTime = 5;
            isFrying = false;
            Debug.Log("Meat is ready!");
            Debug.Log(meatCount);
            _pickUp.PickUping(meatCount, 2, _inventory, ReadyMeatImage, false);
            inGame = false;
            Player.canmove = true;
            _miniGameUI.SetActive(false);
            dragingMeat.position = meatStartPos.position;
            fryText.gameObject.SetActive(false);
       
        }
        if (!isFrying && Array.IndexOf(_inventory.ItemID, 1) != -1 && Input.GetKeyDown(KeyCode.E) && _usable)
        {
            _usable = false;
            inGame = true;
            Player.canmove = false;
            _miniGameUI.SetActive(true);
        } //не ебу зачем 2 ифа с одинаковыми строками, но так работает
        else if (isFrying && Input.GetKeyDown(KeyCode.E) && _usable)
        {
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
