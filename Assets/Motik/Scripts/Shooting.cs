using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    
    void Start()
    {
       
    }
    

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
        
    {
        
        GameObject bullet=Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody rb=bullet .GetComponent<Rigidbody>();
        rb.velocity = firePoint.up * bulletSpeed;
        
        
    }
}
