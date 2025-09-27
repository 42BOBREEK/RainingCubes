using System.Collections.Generic;
using UnityEngine;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if(_pool.Count > 0)
        {
            GameObject obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(_cubePrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        if(obj.TryGetComponent<Cube>(out Cube cube) == true)
        {
            cube.GetComponent<ColorChanger>().ResetColor();
        }
        
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
}
