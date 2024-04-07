using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MeatMiniGame : MonoBehaviour
{
    public GameObject miniGameUI;
    public TMP_Text meatPiecesText;
    [SerializeField] public static int meatPieceCount = 1;
    private void Update()
    {
        meatPiecesText.text = "Pieces of meat: " + meatPieceCount;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("cuttingBoard") && ItemPickUp.isPicked == true)
        {
            miniGameUI.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("cuttingBoard"))
        {
            miniGameUI.SetActive(false);
        }
    }
}
