using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasMiniGame : MonoBehaviour
{
    
    [SerializeField] private TMP_Text fryText;
    [SerializeField] private float fryingTimeBase;
    [SerializeField] private float overCookTimeBase;
    public float fryingTime = 10; //����� �����
    public float overCookTime = 10; //����� ���������

    [Space, Space]

    private bool isFrying = false;
    private bool isFried = false;
    private bool _usable;
    private bool inGame;
    private int _needSum;
    private bool _isStarted = true;

    [Space, Space]

    [SerializeField] private Inventory _inventory;
    [SerializeField] private PickUp _pickUp;
    [SerializeField] private float _distanceForDrag;
    [SerializeField] private float maxDistanceFromObj;
    [SerializeField] private GameObject _miniGameUI;

    [Space, Space]

    [SerializeField] private GameObject rubbishBin;
    [SerializeField] private GameObject ReadyMeatImage;
    [SerializeField] private GameObject meatReadyButton;
    [SerializeField] private GameObject[] meatNotifications; //��� ���������� � ��������� ����: [0] - meatIsFriyng; [1] - meatReady; [2] - meatIsBurnt

    [Space, Space]

    [SerializeField] private Image meatImage;
    [SerializeField] private Sprite rawMeatSprite; //�����
    [SerializeField] private Sprite friedMeatSprite; //��������
    [SerializeField] private GameObject[] meatOnTable;
    public int Sum = 0;



    private void Update()
    {

                                                                        ////////////// ��� ������� ����� \\\\\\\\\\\\\\\
        if (Sum == _needSum && _isStarted == false)
        {
            Debug.Log(11111111);
            _isStarted = isFrying = true;
        }
        
        if (isFried)
        {
            overCookTime -= Time.deltaTime;
        }
        
        if(isFrying)
        {
            meatNotifications[0].SetActive(true);
            fryingTime -= Time.deltaTime;
            fryText.text = $"Wait, meat is frying. Left {Convert.ToInt32(fryingTime)} seconds";
        }


        if (fryingTime <= 0 && isFrying == true)
        {
            fryText.text = $"You have {Convert.ToInt32(overCookTime)} seconds to take meat!";
            isFried = true;
            isFrying = false;
            meatImage.sprite = friedMeatSprite;
            meatNotifications[0].SetActive(false);
            meatReadyButton.SetActive(true);
            meatNotifications[1].SetActive(true);
            
        }

        if (overCookTime <= 0 && isFried == true)
        {
            isFried = false;
            meatNotifications[2].SetActive(true);
            rubbishBin.SetActive(true);
            fryText.text = "The meat was burnt";
            meatImage.color = Color.gray;
            meatNotifications[0].SetActive(false);
            meatReadyButton.SetActive(false);
            meatNotifications[1].SetActive(false);
        }

                                                            ////////////// ��� ��������� ��������� ���������� \\\\\\\\\\\\\\\
               
        if (inGame == false && Array.IndexOf(_inventory.ItemID, 1) != -1 && Input.GetKeyDown(KeyCode.E) && _usable) 
        {
            meatOnTable[1].gameObject.SetActive(false);
            meatOnTable[2].gameObject.SetActive(false);
            if (_inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)] >= 1)
            {
                _needSum++;
                meatOnTable[0].gameObject.SetActive(true);
                _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)]--;
            }
            if (_inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)] >= 1)
            {
                _needSum++;
                meatOnTable[1].gameObject.SetActive(true);
                _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)]--;
            }
            if (_inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)] >= 1)
            {
                _needSum++;
                meatOnTable[2].gameObject.SetActive(true);
                _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)]--;
            }
            fryingTime = fryingTimeBase;
            overCookTime = overCookTimeBase;
            inGame = true;
            isFried = _usable = Player.canmove = _isStarted = false;
            _miniGameUI.SetActive(true);
        }
        else if (inGame == false && Input.GetKeyDown(KeyCode.E) && _usable && isFrying) //���� ��� ���� ��� �� ����� ���� �������� ������� �������� ������
        {
            _usable = Player.canmove = false;
            inGame = true;
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
