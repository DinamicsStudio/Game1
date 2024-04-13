using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _clientPrefab;
    [SerializeField] private float _spawnCooldown = 3f;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private GameObject _orderPosition;
    [SerializeField] private SitTables _sitTables;
    
    private void Update()
    {
        _spawnCooldown -= Time.deltaTime;
        if (_spawnCooldown <= 0)
        {
            for(int i=0;i<_sitTables.IsReserved.Length;i++)
            {
                if (_sitTables.IsReserved[i] == false)
                {
                    _sitTables.IsReserved[i] = true;
                    _spawnCooldown = 20;
                    GameObject sp = Instantiate(_clientPrefab, _spawnPos.position, Quaternion.identity);
                    sp.GetComponent<Client>().GetNumberOfTable(i);
                    break;
                }
            }
        }    
    }
}
