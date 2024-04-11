using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Ray ray=Camera.main.ScreenPointToRay(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        

        if (Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;

            Vector3 direction=targetPosition - transform.position;

            transform.LookAt(new Vector3 (targetPosition.x,0,targetPosition.z));
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
