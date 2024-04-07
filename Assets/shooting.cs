using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform firePoint;
    public float bulletSpeed;
    void Start()
    {
        
    }
    void Shoot()
    {
        GameObject bullet=Instantiate(bulletPref,firePoint.position,firePoint.rotation);    

        Rigidbody rb=bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward*bulletSpeed,ForceMode.Impulse);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
