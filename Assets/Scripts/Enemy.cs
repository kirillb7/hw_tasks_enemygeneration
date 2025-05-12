using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private bool _isMoving = true;

    public void Initiate(SpawnPoint spawnPoint)
    {
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.Euler(spawnPoint.Direction);

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_isMoving)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;

            yield return null;
        }
    }
}
