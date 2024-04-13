using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    private float spawnCooldown = 3;
    public Transform spawnPos;
    [SerializeField] public GameObject[] tablesToSitForClient;
    [SerializeField] public GameObject orderPosToClient;
    private PlaceToSit orderPos;
    private void Start()
    {
        orderPos = orderPosToClient.GetComponent<PlaceToSit>();
    }

    private void Update()
    {
        if (orderPos.isFree)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                spawnCooldown = 20;
                Instantiate(clientPrefab, spawnPos.position, Quaternion.identity);
            }
        }    
    }
}
