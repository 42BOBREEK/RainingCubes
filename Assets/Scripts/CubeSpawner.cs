using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubesPool _cubesPool;
    [SerializeField] private Transform[] _spawningPositions;

    private void Start()
    {
        InvokeRepeating("CreateCube", 1f, 2f);
    }

    private void CreateCube()
    {
        int spawningPositionIndex = Random.Range(0, _spawningPositions.Length);

        GameObject cube = _cubesPool.GetObject();

        cube.transform.position = _spawningPositions[spawningPositionIndex].position;
        cube.transform.rotation = _spawningPositions[spawningPositionIndex].rotation;

        StartCoroutine(DeactivateCube(cube));
    }

    IEnumerator DeactivateCube(GameObject cube)
    {
        Cube cubeScript = cube.GetComponent<Cube>();

        if(cubeScript.colorChanged == false)
            yield return null;

         yield return new WaitForSeconds(cube.GetComponent<Cube>().destroyDelay);

         _cubesPool.ReturnObject(cube);
    }
}
