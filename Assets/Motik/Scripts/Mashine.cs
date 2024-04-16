using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Machine : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 10f; // Скорострельность в выстрелах в секунду
    public float bulletSpeed = 10f;

    private bool isFiring = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
            InvokeRepeating("Shoot", 0f, 1f / fireRate);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * bulletSpeed;
        }
    }
}
