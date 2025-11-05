using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextInfo<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] private Pool<T> _pool;

    private TMP_Text _valuesText;

    private void Awake()
    {
        _valuesText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _pool.ValueChanged += RefreshValues;
    }

    private void OnDisable()
    {
        _pool.ValueChanged -= RefreshValues;
    }

    private void RefreshValues()
    {
        _valuesText.text =
            $"{typeof(T).Name}s:\n" +
            $"Создано(instantiate): {_pool.SpawnedObjects}\n" +
            $"Создано на сцене: {_pool.SpawnedObjectsOnScene}\n" +
            $"Активно на сцене: {_pool.ActiveObjects}";
    }
}
