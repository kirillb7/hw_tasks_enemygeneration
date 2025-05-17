using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Target _target;

    public Enemy Prefab => _prefab;
    public Target Target => _target;
}
