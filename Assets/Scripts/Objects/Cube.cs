using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour, IPoolable
{
    [SerializeField] private int _minimumLifeSeconds;
    [SerializeField] private int _maximumLifeSeconds;
    [SerializeField] private Color _colorToChange;
    [SerializeField] private int DelayActivity;

    private ColorChanger _colorChanger;
    private bool _isActive;
    private Rigidbody _rigidbody;

    public bool IsColorChanged { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;
        _isActive = true;

        _colorChanger = GetComponent<ColorChanger>();

        DelayActivity = Random.Range(_minimumLifeSeconds, _maximumLifeSeconds + 1);
        StartCoroutine(WaitThenDeactivate());
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Platform>() != null)
        {
             ChangeColor();
        }
    }

    private IEnumerator WaitThenDeactivate()
    {
        yield return new WaitForSeconds(DelayActivity);

        Deactivate();
    }

    public void Deactivate()
    {
        _isActive = false;
        _colorChanger.ResetColor();
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
