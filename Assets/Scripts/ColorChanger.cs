using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private Color _defaultColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    public void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void ResetColor()
    {
        _renderer.material.color = _defaultColor;
    }
}
