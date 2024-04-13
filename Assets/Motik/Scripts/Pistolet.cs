using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Pistolet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float relodTime = 2.0f;
    private bool isReloading = false;
    private bool isReadyToShoot = true;
    public int bullets = 10; //максимальное в магазине, для UI
    public int maxBullets=10;
    private int bullet=1;
    public TMP_Text bulletsText;
    
    
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
       bulletsText.text = bullets.ToString() + " / " + maxBullets.ToString();
       if(Input.GetButtonDown("Fire1")&& isReadyToShoot&&!isReloading)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullets = maxBullets;
            
            isReadyToShoot=true;
            
        }
        
        
        if (bullets <= 0)
        {
            isReadyToShoot = false;
        }
        
        
    }
    void Shoot()
        
    {



        bullets--;  
        GameObject bullet=Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody rb=bullet .GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        isReadyToShoot = true;
        
        
        
    }
    IEnumerator Reload()
    {
        isReloading = true;
        

        yield return new WaitForSeconds(relodTime);

       
        isReloading=false;
    }

    

}
