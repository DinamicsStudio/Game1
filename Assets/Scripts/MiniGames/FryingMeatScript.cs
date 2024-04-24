using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class FryingMeatScript : MonoBehaviour
{
    [SerializeField] private float _distanceForDrag;
    [SerializeField] private RectTransform _centerOfPan;
    [SerializeField] private RectTransform _centerOfRubbish;

    [Space, Space]

    [SerializeField] private float maxDistanceFromObj;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GasMiniGame _gasMiniGame;

    [Space, Space]

    private int _block;
    private bool isFrying = false;

    [Space, Space]

    [SerializeField] private Vector2 _pos;
    [SerializeField] private Sprite _readyMeat;
    [SerializeField] private Sprite _overReadyMeat;
    public void Draging(RectTransform obj)
    {
        if (Vector3.Distance(obj.position, Input.mousePosition) <= _distanceForDrag)
        {
            obj.position = Input.mousePosition;
        }
    }
    public void EndDrag(RectTransform obj)
    {
        float panDistance = Vector3.Distance(obj.position, _centerOfPan.position);
        if (panDistance <= maxDistanceFromObj && isFrying == false && _block==0)
        {
            isFrying = true;
            _gasMiniGame.Sum++;

        }
        float rubbishDistance = Vector3.Distance(obj.position, _centerOfRubbish.position);
        if (rubbishDistance <= maxDistanceFromObj && _gasMiniGame.overCookTime <= 0)
        {
            gameObject.GetComponent<RectTransform>().position = _pos;
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_gasMiniGame.fryingTime <= 0 && _gasMiniGame.overCookTime > 0) gameObject.GetComponent<Sprite>().sprite = _readyMeat;
        if (_gasMiniGame.overCookTime <= 0) { gameObject.GetComponent<Image>().tintColor = Color.black; Debug.Log(12345); }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Meat")) _block++;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Meat")) _block++;
    }
}
