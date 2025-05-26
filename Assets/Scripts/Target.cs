using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed = 3;

    private bool _isMoving = true;
    private int _currentWaypoint = 0;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private void ChangeWaypoint()
    {
        if (++_currentWaypoint >= _waypoints.Count)
        {
            _currentWaypoint = 0;
        }
    }

    private IEnumerator Move()
    {
        while (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);

            if (transform.position == _waypoints[_currentWaypoint].position)
            {
                ChangeWaypoint();
            }

            yield return null;
        }
    }
}
