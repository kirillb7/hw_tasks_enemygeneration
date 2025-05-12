using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _interval = 2;

    private bool _isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnRandomly());
    }

    private void Spawn(SpawnPoint spawnPoint)
    {
        Instantiate(_prefab).Initiate(spawnPoint);
    }

    private SpawnPoint GetSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[index];
    }

    private IEnumerator SpawnRandomly()
    {
        while (_isSpawning)
        {
            Spawn(GetSpawnPoint());

            yield return new WaitForSeconds(_interval);
        }
    }
}
