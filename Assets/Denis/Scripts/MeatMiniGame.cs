using System;
using TMPro;
using UnityEngine;

public class MeatMiniGame : MonoBehaviour
{
    public event Action MeatUpdate;
    public int meatCountInThis = 0; 
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private TMP_Text meatPiecesText;
    private bool _usable;
    private bool InGame;
    [SerializeField] private float distance;
    [SerializeField] private GameObject[] polosi;
    [SerializeField] private GameObject[] meats;

    [SerializeField] private Animator anim2;
    [SerializeField] private float[] limits;
    public GameObject meatTextObject; //in game

    private int i = 0;
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
                MeatUpdate.Invoke();
                meatCountInThis = i = 0;
                InGame = false;
                Player.canmove = true;
                miniGameUI.SetActive(false);
                meatTextObject.SetActive(true);
                //Destroy(ItemPickUp.UpItem.gameObject);
                //ItemPickUp.usable = false; ItemPickUp.isPicked = false;
                PickUp.isPicked = false;
                
                
            }
        }
    }
    private void Update()
    {
        if(PickUp.isPicked == true && Input.GetKeyDown(KeyCode.E) && _usable) 
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
            meatTextObject.SetActive(true);
        }
    }
}
