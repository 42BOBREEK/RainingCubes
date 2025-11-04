using UnityEngine;
using System;
using System.Collections.Generic;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] private T _objectPrefab;

    private Queue<T> _pool = new Queue<T>();

    public int SpawnedObjects { get; private set; }
    public int SpawnedObjectsOnScene { get; private set; }
    public int ActiveObjects { get; private set; }

    public event Action ValueChanged;
    public event Action<T> ObjectReturned;

    public T GetObject()
    {
        ActiveObjects++;
        if(_pool.Count > 0)
        {
            T obj = _pool.Dequeue();
            obj.SetActivity(true);

            SpawnedObjectsOnScene++;
            ValueChanged?.Invoke();
            return obj;
        }

        SpawnedObjects++;
        ValueChanged?.Invoke();

        return Instantiate(_objectPrefab);
    }

    public void ReturnObject(T obj)
    {
        if(obj.TryGetComponent<ColorChanger>(out ColorChanger colorChanger) == true)
            colorChanger.ResetColor();
        
        ObjectReturned?.Invoke(obj);

        obj.SetActivity(false);
        _pool.Enqueue(obj);

        ActiveObjects--;
        ValueChanged?.Invoke();
    }
}
