using UnityEngine;
using System.Collections;

public class TransparencyChanger : MonoBehaviour
{
    [SerializeField] private float _minimumTransparency;
    [SerializeField] private float _maximumTransparencyChange;
    [SerializeField] private bool _isDissapearing;

    private Renderer _renderer;
    private float _currentTransparency;

    private Color _color;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
    }

    private void Start()
    {
        Dissapear();
    }

    private IEnumerator DissapearSlowly()
    {
        _currentTransparency = _color.a;

        while(_isDissapearing)
        {
            _currentTransparency = Mathf.MoveTowards(_currentTransparency, _minimumTransparency, _maximumTransparencyChange * Time.deltaTime);

            var color = _color;
            color.a = _currentTransparency;
            _renderer.material.color = color;

            yield return null;
        }
    }

    public void Dissapear()
    {
        StartCoroutine(DissapearSlowly());
    }
}
