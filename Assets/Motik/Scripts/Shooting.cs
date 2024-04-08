using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float relodTime = 2.0f;
    private bool isReloading = false;
    private bool isReadyToShoot = true;
    public int bullets = 10;
    private int bullet=1;
    public TextMeshProUGUI bulletText;
    
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1")&& isReadyToShoot&&!isReloading)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && isReloading)
        {
            StartCoroutine(Reload());
        }
        if(Input.GetKeyUp(KeyCode.R) )
        {
            isReloading = true;
        }
        if (isReloading)
        {
            bullets = 10;
            isReadyToShoot=true;
        }
        
    }
    void Shoot()
        
    {



        bullets--;  
        GameObject bullet=Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody rb=bullet .GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        isReadyToShoot = false;
        
        StartCoroutine(ReadyToShoot(relodTime));
        
        
    }
    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(relodTime);

        isReadyToShoot=true;
        isReloading=false;
    }

    IEnumerator ReadyToShoot(float delay)
    {
yield return new WaitForSeconds(delay);
        isReadyToShoot=true;
    }

}
