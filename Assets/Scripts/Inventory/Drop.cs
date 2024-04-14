using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void SpawnDroppedItem()
    {
        Vector3 spawnDirection = player.forward * 2f; // Множитель 2 - это расстояние спавна
        Vector3 spawnPosition = player.position + spawnDirection;
        Instantiate(item, spawnPosition, Quaternion.identity);
    }
}