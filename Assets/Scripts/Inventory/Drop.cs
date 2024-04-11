using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject item;
    [SerializeField] private Transform player;
    public void SpawnDroppedItem()
    {
        Vector3 spawnDirection = player.forward * 2f; // Множитель 2 - это расстояние спавна
        Vector3 spawnPosition = player.position + spawnDirection;
        Instantiate(item, spawnPosition, Quaternion.identity);
    }
}