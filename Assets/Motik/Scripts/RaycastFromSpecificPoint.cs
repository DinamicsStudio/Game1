using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromSpecificPoint : MonoBehaviour
{
    public Transform raycastOrigin; // Точка, из которой будет исходить луч
    public float raycastDistance = 30f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRaycast();
        }
    }

    void ShootRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, raycastDistance))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
        }
    }
}
