using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private bool _isMoving = true;

    private void Start()
    {
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
