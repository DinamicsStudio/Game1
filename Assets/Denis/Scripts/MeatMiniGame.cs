using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MeatMiniGame : MonoBehaviour
{
    public GameObject miniGameUI;
    public TMP_Text meatPiecesText;
    public bool usable;
    public bool InGame;
    public bool IsDraging = false;
    public float distance;
    public GameObject[] polosi;
    public Animator[] anim1;
    public Animator anim2;
    public float[] limits;

    private int i = 0;

    public void Draging(RectTransform obj)
    {
        
        if (Vector3.Distance(obj.position, Input.mousePosition) <= distance)
        {
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(RectTransform obj)
    {
        if (Convert.ToInt32(3 - Mathf.Round(Mathf.Abs(obj.position.x - polosi[i / 2].GetComponent<Transform>().position.x) / 30))>=1)
        {
            polosi[i / 2].SetActive(false);
            meatPieceCount += Convert.ToInt32(3 - Mathf.Round(Mathf.Abs(obj.position.x - polosi[i / 2].GetComponent<Transform>().position.x) / 30));
            //anim1[i].SetTrigger("trig");
            i += 2;
            if(i/2<polosi.Length)
            {
                polosi[i / 2].SetActive(true);
            }
            else
            {
                meatPieceCount = 0;
                i = 0;
                InGame = false;
                Player.canmove = true;
                miniGameUI.SetActive(false);
            }
        }
        else
        {
            //anim2.SetTrigger("trigger");
        }
    }

    [SerializeField] public static int meatPieceCount = 1;
    private void Update()
    {
        if(ItemPickUp.isPicked == true && Input.GetKeyDown(KeyCode.E) && usable)
        {
            polosi[0].SetActive(true);
            InGame = true;
            Player.canmove = false;
            miniGameUI.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && InGame)
        {
            InGame = false;
            Player.canmove = true;
            miniGameUI.SetActive(false);
        }
        meatPiecesText.text = "Pieces of meat: " + meatPieceCount;
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
        }
    }
}
