using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlitaMninGame : MonoBehaviour
{
    private bool usable;
    private void OnTriggerEnter(Collider other)
    {
        usable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        usable = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && usable)
        {

        }
    }
}

