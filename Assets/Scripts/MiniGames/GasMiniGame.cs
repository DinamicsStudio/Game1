using System;
using TMPro;
using UnityEngine;

public class GasMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private TMP_Text fryText;
    [SerializeField] private float fryingTime; //время жарки
    bool isFrying = false;

    private bool _usable;
    private bool inGame;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private PickUp _pickUp;

    [SerializeField] private float _distanceForDrag;
    [SerializeField] private Transform pan;
    [SerializeField] private float maxDistanceFromPan; //от сковородки до мяса
    [SerializeField] private RectTransform dragingMeat; //для указа позиции
    [SerializeField] private RectTransform meatStartPos;
    [SerializeField] private RectTransform _centerOfPan;

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
        float distance = Vector3.Distance(obj.position, _centerOfPan.position);
        if (distance <= maxDistanceFromPan && isFrying == false)
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
            for (int i = 0; i < meatCount; i++) { 
                _pickUp.PickUping(12, 2, _inventory, ReadyMeatImage, false);
            }
            
            inGame = false;
            Player.canmove = true;
            _miniGameUI.SetActive(false);
            dragingMeat.position = meatStartPos.position;
            fryText.gameObject.SetActive(false);
       
        }
        if (inGame == false && Array.IndexOf(_inventory.ItemID, 1) != -1 && Input.GetKeyDown(KeyCode.E) && _usable) 
        {
            _usable = false;
            inGame = true;
            Player.canmove = false;
            _miniGameUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inGame == true)
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
