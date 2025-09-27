using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minimumLifeSeconds;
    [SerializeField] private int _maximumLifeSeconds;
    [SerializeField] private Color _colorToChange;
    [SerializeField] private ColorChanger _colorChanger;

    public bool ColorChanged { get; private set; }
    public int DelayActivity { get; private set; }

    private void Start()
    {
        _colorChanger = GetComponent<ColorChanger>();
        DelayActivity = Random.Range(_minimumLifeSeconds, _maximumLifeSeconds + 1);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Platform>() != null)
        {
             ChangeColor();
        }
    }

    public void SetActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }

    public void ChangeColor()
    {
        _colorChanger.ChangeColor(_colorToChange);

        ColorChanged = !ColorChanged;
    } 
}
