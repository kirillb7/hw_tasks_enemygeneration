using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private bool _isMoving = true;
    private Target _target;

    public void Initiate(Vector3 position, Target target)
    {
        transform.position = position;
        _target = target;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_isMoving)
        {
            transform.LookAt(_target.transform, Vector3.up);
            transform.position += transform.forward * _speed * Time.deltaTime;

            yield return null;
        }
    }
}
