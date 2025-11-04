using UnityEngine;
using System.Collections;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] private Pool<T> _pool;
    [SerializeField] private Transform[] _spawningPositions;
    [SerializeField] private int _spawningCooldown;
    [SerializeField] private bool _isSpawning;

    private void Start()
    {
        StartCoroutine(CreateObjects());
    }

    private void CreateObject()
    {
        int spawningPositionIndex = Random.Range(0, _spawningPositions.Length);

        SpawnAt(_spawningPositions[spawningPositionIndex].position);
    }

    private IEnumerator CreateObjects()
    {
        while(_isSpawning)
        {
            CreateObject();

            yield return new WaitForSeconds(_spawningCooldown);
        }
    }

    private IEnumerator DeactivateObject(T obj)
    {
        while(obj.IsActive() == true)
            yield return null;

        _pool.ReturnObject(obj);
    }

    public void SpawnAt(Vector3 positionToSpawnAt)
    {
        T obj = _pool.GetObject();

        obj.transform.position = positionToSpawnAt;

        StartCoroutine(DeactivateObject(obj));
    }
}
