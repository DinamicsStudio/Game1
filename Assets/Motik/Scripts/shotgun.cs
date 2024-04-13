using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int pellets = 10;
    public float spreadAngle = 20f;
    public int bullets = 7; //максимальное в магазине, для UI
    public int maxBullets = 7;
    public TMP_Text bulletsText;
    private bool isShoot = true;
    public float fireRate = 6f;
    private float lastFRireTime;

    void Update()
    {
        bulletsText.text = bullets.ToString() + " / " + maxBullets.ToString();
        if (Input.GetButtonDown("Fire1")&&Time.time>lastFRireTime+fireRate&&bullets>0)
        {
            Shoot();
            bullets--;
            lastFRireTime = Time.time;
        }
        if(Input.GetKey(KeyCode.R))
        {
            bullets = maxBullets; 
        }
        if (bullets <= 0)
        {
            isShoot = false;
        }
    }

    void Shoot()
    {
    
        
        for (int i = 0; i < pellets; i++)
        {
            isShoot=true;
            Vector3 spawnPosition = transform.position + transform.forward * Random.Range(0.5f, 1.0f);
            Quaternion spawnRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f);

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, transform.rotation * spawnRotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
        }
    }
}