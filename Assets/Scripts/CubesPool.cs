using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Queue<Cube> _pool = new Queue<Cube>();

    public IEnumerator WaitForDeactivatedCube(Cube cube)
    { 
        if(cube.IsDeactivated == false)
        {
            yield return null;
        }
        else 
        {
            print(cube.IsDeactivated);
            ReturnCube(cube);
        }
    } 

    public Cube GetCube()
    {
        if(_pool.Count > 0)
        {
            Cube cube = _pool.Dequeue();
            cube.SetActivity(true);
            return cube;
        }

        return Instantiate(_cubePrefab);
    }

    public void ReturnCube(Cube cube)
    {
        cube.GetComponent<ColorChanger>().ResetColor();
        
        cube.SetActivity(false);
        _pool.Enqueue(cube);
    }
}
