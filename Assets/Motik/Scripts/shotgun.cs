using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSpread : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int pellets = 10;
    public float spreadAngle = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            Vector3 spawnPosition = transform.position + transform.forward * Random.Range(0.5f, 1.0f);
            Quaternion spawnRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f);

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, transform.rotation * spawnRotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
        }
    }
}