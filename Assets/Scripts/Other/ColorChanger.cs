using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Color _defaultColor;
    private Renderer _renderer;

    private void Awake()
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
