using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubesPool _cubesPool;
    [SerializeField] private Transform[] _spawningPositions;
    [SerializeField] private int _spawningCooldown;
    [SerializeField] private bool _isSpawning;

    private void Start()
    {
        StartCoroutine(CreateCubes());
    }

    private void CreateCube()
    {
        int spawningPositionIndex = Random.Range(0, _spawningPositions.Length);

        Cube cube = _cubesPool.GetCube();

        cube.transform.position = _spawningPositions[spawningPositionIndex].position;
        cube.transform.rotation = _spawningPositions[spawningPositionIndex].rotation;

        _cubesPool.StartCoroutine(_cubesPool.WaitForDeactivatedCube(cube));
        cube.StartCoroutine(cube.DeactivateCube());
    }

    private IEnumerator CreateCubes()
    {
        while(_isSpawning)
        {
            CreateCube();

            yield return new WaitForSeconds(_spawningCooldown);
        }
    }

    /*private IEnumerator DeactivateCube(Cube cube)
    {
        if(cube.IsColorChanged == false)
            yield return null;

        yield return new WaitForSeconds(cube.DelayActivity);

        _cubesPool.ReturnCube(cube);
    }*/
}
