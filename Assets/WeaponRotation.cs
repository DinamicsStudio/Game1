using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray=Camera.main.ScreenPointToRay(new Vector3 (Input.mousePosition.x,transform.position.y, Input.mousePosition.z ));
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;

            Vector3 direction=targetPosition - transform.position;

            transform.LookAt(targetPosition);
        }
    }
}
