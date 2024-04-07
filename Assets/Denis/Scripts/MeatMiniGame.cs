using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MeatMiniGame : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public GameObject miniGameUI;
    public TMP_Text meatPiecesText;
    public bool usable;
    public bool InGame;
    public bool IsDraging = false;
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        IsDraging = true;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        IsDraging = false;
    }


    [SerializeField] public static int meatPieceCount = 1;
    private void Update()
    {
        
        if(ItemPickUp.isPicked == true && Input.GetKeyDown(KeyCode.E) && usable)
        {
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
