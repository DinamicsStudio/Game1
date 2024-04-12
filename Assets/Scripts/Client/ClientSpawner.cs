using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    private float spawnCooldown = 3;
    public Transform spawnPos;
    [SerializeField] public GameObject[] tablesToSitForClient;
    private void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if(spawnCooldown <= 0)
        {
            spawnCooldown = 10;
            Instantiate(clientPrefab, spawnPos.position, Quaternion.identity);
        }
    }
}
