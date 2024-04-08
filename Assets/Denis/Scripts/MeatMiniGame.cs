using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MeatMiniGame : MonoBehaviour
{
    [SerializeField] public static int meatPieceCount = 1; // счетчик кусков мяса вообщем в игре
    public static int meatCountInThis = 1; //счетчик мяса в мини игре
    public GameObject miniGameUI;
    public TMP_Text meatPiecesText;
    public bool usable;
    public bool InGame;
    public bool IsDraging = false;
    public float distance;
    public GameObject[] polosi;
    public GameObject[] meats;
    //public Animator[] anim1;
    public Animator anim2;
    public float[] limits;
    //text
    public TMP_Text meatTextInGame; //число мяса во время игры
    public GameObject meatTextObject; //in game
    ItemPickUp itemPickUp;

    private int i = 0;

    private void Start()
    {
        itemPickUp = FindAnyObjectByType<ItemPickUp>();
    }
    public void Draging(Transform obj)
    {
        Debug.Log(1);
        if (Vector3.Distance(obj.position, Input.mousePosition) <= distance)
        {
            Debug.Log(Input.mousePosition);
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(Transform obj)
    {
        if (Convert.ToInt32(3 - Mathf.Round(Mathf.Abs(obj.position.x - polosi[i / 2].GetComponent<Transform>().position.x) / 30))>=1)
        {
            polosi[i / 2].SetActive(false);
            meats[i / 2].SetActive(false);
            meatCountInThis += Convert.ToInt32(3 - Mathf.Round(Mathf.Abs(obj.position.x - polosi[i / 2].GetComponent<Transform>().position.x) / 30));
            anim2.SetTrigger("trig");
            i += 2;
            if(i/2<polosi.Length)
            {
                polosi[i / 2].SetActive(true);
            }
            else
            {
                meatPieceCount += meatCountInThis;
                meatCountInThis = 0;
                //meatPieceCount = 0;
                i = 0;
                InGame = false;
                Player.canmove = true;
                miniGameUI.SetActive(false);
                meatTextObject.SetActive(true);
                Destroy(itemPickUp.UpItem.gameObject);
                itemPickUp.usable = false; ItemPickUp.isPicked = false;
                
            }
        }
    }

    private void Update()
    {
        if(ItemPickUp.isPicked == true && Input.GetKeyDown(KeyCode.E) && usable)
        {
            for(int i=0;i<meats.Length;i++)
            {
                meats[i].SetActive(true);
            }
            polosi[0].SetActive(true);
            InGame = true;
            Player.canmove = false;
            miniGameUI.SetActive(true);
            meatTextObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && InGame)
        {
            InGame = false;
            Player.canmove = true;
            miniGameUI.SetActive(false);
            meatTextObject.SetActive(true);
        }
        meatPiecesText.text = "Pieces of meat: " + meatCountInThis;
        meatTextInGame.text = meatPieceCount.ToString();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            usable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            usable = false;
            meatTextObject.SetActive(true);
        }
    }
}
