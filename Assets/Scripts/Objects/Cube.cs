using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour, IPoolable
{
    [SerializeField] private int _minimumLifeSeconds;
    [SerializeField] private int _maximumLifeSeconds;
    [SerializeField] private Color _colorToChange;
    [SerializeField] private int DelayActivity;

    private ColorChanger _colorChanger;
    private bool _isActive;

    public bool IsColorChanged { get; private set; }

    private void OnEnable()
    {
        _isActive = true;

        _colorChanger = GetComponent<ColorChanger>();

        DelayActivity = Random.Range(_minimumLifeSeconds, _maximumLifeSeconds + 1);
        StartCoroutine(Deactivate());
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Platform>() != null)
        {
             ChangeColor();
        }
    }

    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(DelayActivity);

        _isActive = false;
    }

    public void ChangeColor()
    {
        _colorChanger.ChangeColor(_colorToChange);

        IsColorChanged = !IsColorChanged;
    } 

    public bool IsActive()
    {
        return _isActive;
    }

    public void SetActivity(bool activity)
    {
        _isActive = activity;
        gameObject.SetActive(activity);
    }
}
