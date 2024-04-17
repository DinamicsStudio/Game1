using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private TMP_Text fryText;
     private float fryingTime = 10; //время жарки
    private float overCookTime = 10; //время пережарки
    private bool isFrying = false;
    private bool isFried = false;

    [Space, Space]

    private bool _usable;
    private bool inGame;

    [Space, Space]

    [SerializeField] private Inventory _inventory;
    [SerializeField] private PickUp _pickUp;

    [Space,Space]

    [SerializeField] private float _distanceForDrag;
    [SerializeField] private float maxDistanceFromObj; //от взаимодействующего предмета

    [Space, Space]

    [SerializeField] private GameObject rubbishBin;
    [SerializeField] private RectTransform _centerOfRubbish;
    [SerializeField] private RectTransform dragingMeat; //для указа позиции
    [SerializeField] private RectTransform meatStartPos;
    [SerializeField] private RectTransform _centerOfPan;

    [Space, Space]

    private int meatCount;
    public GameObject ReadyMeatImage;
    [SerializeField] private GameObject meatReadyButton;
    [SerializeField] private GameObject[] meatNotifications; //все оповещения о состоянии мяса: [0] - meatIsFriyng; [1] - meatReady; [2] - meatIsBurnt

    [Space, Space]

    [SerializeField] private Image meatImage;
    [SerializeField] private Sprite rawMeatSprite; //сырое
    [SerializeField] private Sprite friedMeatSprite; //жаренное


    public void Draging(Transform obj)
    {
        if (Vector3.Distance(obj.position, Input.mousePosition) <= _distanceForDrag)
        {
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(Transform obj)
    {
        float panDistance = Vector3.Distance(obj.position, _centerOfPan.position);
        if (panDistance <= maxDistanceFromObj && isFrying == false)
        {
            isFrying = true;
            fryText.gameObject.SetActive(true);
            meatCount = _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)];
            _inventory.ObjCountInSlot[Array.IndexOf(_inventory.ItemID, 1)] = 0;

        }
        float rubbishDistance = Vector3.Distance(obj.position, _centerOfRubbish.position);
        if (rubbishDistance <= maxDistanceFromObj && overCookTime <= 0)
        {
            MeatInTrash();
        }
    }
    private void Update()
    {
        if (isFried)
        {
            overCookTime -= Time.deltaTime;
        }
        if(overCookTime < 0)overCookTime = 0;
        if(fryingTime < 0)fryingTime = 0;
        if(isFrying)
        {
            meatNotifications[0].SetActive(true);
            fryingTime -= Time.deltaTime;
            fryText.text = $"Wait, meat is frying. Left {Convert.ToInt32(fryingTime)} seconds";
        }
        if (fryingTime <= 0)
        {
            fryText.text = $"You have {Convert.ToInt32(overCookTime)} seconds to take meat!";
            isFried = true;
            meatImage.sprite = friedMeatSprite;
            meatNotifications[0].SetActive(false);
            meatReadyButton.SetActive(true);
            meatNotifications[1].SetActive(true);
            if (overCookTime <= 0)
            {
                meatNotifications[2].SetActive(true);
                rubbishBin.SetActive(true);
                fryText.text = "The meat was burnt";
                isFried = true;
                meatImage.color = Color.gray;
                meatNotifications[0].SetActive(false);
                meatReadyButton.SetActive(false);
                meatNotifications[1].SetActive(false);
            }
        }
        if (inGame == false && Array.IndexOf(_inventory.ItemID, 1) != -1 && Input.GetKeyDown(KeyCode.E) && _usable) 
        {
            _usable = false;
            inGame = true;
            Player.canmove = false;
            _miniGameUI.SetActive(true);
        }
        else if (inGame == false && Input.GetKeyDown(KeyCode.E) && _usable && isFrying) //надо для того что бы игрок смог смотреть сколько осталось жарить
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
    public void MeatReady()
    {
        fryingTime = 10;
        isFrying = false;
        isFried = false;
        meatReadyButton.SetActive(false);
        meatNotifications[1].SetActive(false);
        meatImage.sprite = rawMeatSprite;
        for (int i = 0; i < meatCount; i++)
        {
            _pickUp.PickUping(12, 2, _inventory, ReadyMeatImage, false);
        }
        inGame = false;
        Player.canmove = true;
        _miniGameUI.SetActive(false);
        dragingMeat.position = meatStartPos.position;
        fryText.gameObject.SetActive(false);
    }
    public void MeatInTrash()
    {
        overCookTime = 10;
        fryingTime = 10;
        isFrying = false;
        isFried = false;
        meatReadyButton.SetActive(false);
        meatNotifications[1].SetActive(false);
        meatNotifications[2].SetActive(false);
        meatImage.sprite = rawMeatSprite;
        inGame = false;
        Player.canmove = true;
        rubbishBin.SetActive(true);
        dragingMeat.position = meatStartPos.position;
        fryText.gameObject.SetActive(false);
        meatImage.color = Color.white;
        rubbishBin.SetActive(false);
        _miniGameUI.SetActive(false);

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
