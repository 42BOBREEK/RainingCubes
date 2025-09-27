using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minimumLifeSeconds;
    [SerializeField] private int _maximumLifeSeconds;
    [SerializeField] private Color _colorToChange;
    [SerializeField] private ColorChanger _colorChanger;

    public bool colorChanged { get; private set; }
    public int destroyDelay { get; private set; }

    private void Start()
    {
        _colorChanger = GetComponent<ColorChanger>();
        destroyDelay = Random.Range(_minimumLifeSeconds, _maximumLifeSeconds + 1);
    }
    
    public void ChangeColor()
    {
        _colorChanger.ChangeColor(_colorToChange);

        colorChanged = !colorChanged;
    } 
}
