using UnityEngine;

public class BombsPoolListener : MonoBehaviour
{
    [SerializeField] private Pool<Cube> _cubesPool;
    [SerializeField] private Spawner<Bomb> _bombSpawner;

    private void OnEnable()
    {
        _cubesPool.ObjectReturned += SpawnBombAtCube;
    }

    private void OnDisable()
    {
        _cubesPool.ObjectReturned -= SpawnBombAtCube;
    }

    private void SpawnBombAtCube(Cube cubeToSpawnAt)
    {
        _bombSpawner.SpawnAt(cubeToSpawnAt.transform.position);
    }
}
