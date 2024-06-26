using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    private bool canShoot = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(canShoot&&Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
        
    {
        
        GameObject bullet=Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody rb=bullet .GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        
        
    }
}
