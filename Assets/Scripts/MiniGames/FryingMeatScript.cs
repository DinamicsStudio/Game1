using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingMeatScript : MonoBehaviour
{
    [SerializeField] private float _distanceToMouse;
    void Dragging(RectTransform obj)
    {
        if (Vector3.Distance(obj.position, Input.mousePosition) <= _distanceToMouse) obj.position = Input.mousePosition;
    }
}
