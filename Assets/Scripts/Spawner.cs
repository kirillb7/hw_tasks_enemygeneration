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
        Instantiate(_prefab, spawnPoint.transform.position, Quaternion.Euler(spawnPoint.Direction));
    }

    private SpawnPoint GetSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[index];
    }

    private IEnumerator SpawnRandomly()
    {
        float elapsedTime = 0;

        while (_isSpawning)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _interval)
            {
                elapsedTime = 0;
                Spawn(GetSpawnPoint());
            }

            yield return null;
        }
    }
}
