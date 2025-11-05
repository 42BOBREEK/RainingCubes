using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class TransparencyChanger : MonoBehaviour
{
    private Renderer _renderer;
    private Color _color;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
    }

    public void Dissapear(float duration)
    {
        Color resetColor = new Color(_color.r, _color.g, _color.b, 1f);

        _renderer.material.color = resetColor; 

        Color source = _renderer.material.color;

        StartCoroutine(ChangeTransparencySmoothly(_renderer.material, new(source.r, source.g, source.b, 0f), duration));
    }

    private IEnumerator ChangeTransparencySmoothly(Material material, Color color, float duration)
    {
        Color source = material.color;

        float elapsedSeconds = 0f;

        while (elapsedSeconds < duration)
        {
            elapsedSeconds += Time.deltaTime;

            float transparency = elapsedSeconds / duration;

            material.color = Color.Lerp(source, color, transparency);
            yield return null;
        }
    }
}
