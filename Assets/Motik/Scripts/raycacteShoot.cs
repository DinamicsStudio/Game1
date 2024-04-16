using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycacteShoot : MonoBehaviour
{
    public GameObject raycasteOrigin;
    public float raycastDistance = 15f;
    void Start()
    {
        
    }
    void ShootRaycaste()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycasteOrigin.transform.position, raycasteOrigin.transform.right, raycastDistance);
        if (hit.collider != null)
        {
            Debug.Log("Raycast  hit: " + hit.collider.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRaycaste();
        }
    }
}
