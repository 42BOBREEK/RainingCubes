using System.Collections.Generic;
using UnityEngine;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private Queue<Cube> _pool = new Queue<Cube>();

    public Cube GetCube()
    {
        if(_pool.Count > 0)
        {
            Cube cube = _pool.Dequeue();
            cube.SetActivity(true);
            return cube;
        }

        return Instantiate(_cubePrefab).GetComponent<Cube>();
    }

    public void ReturnCube(Cube cube)
    {
        cube.GetComponent<ColorChanger>().ResetColor();
        
        cube.SetActivity(false);
        _pool.Enqueue(cube);
    }
}
