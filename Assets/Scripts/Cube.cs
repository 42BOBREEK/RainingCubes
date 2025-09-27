using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minimumLifeSeconds;
    [SerializeField] private int _maximumLifeSeconds;
    [SerializeField] private Color _colorToChange;

    private ColorChanger _colorChanger;

    public bool IsColorChanged { get; private set; }
    public bool IsDeactivated { get; private set; }
    public int DelayActivity { get; private set; }

    private void Start()
    {
        IsDeactivated = false;
        _colorChanger = GetComponent<ColorChanger>();
        DelayActivity = UnityEngine.Random.Range(_minimumLifeSeconds, _maximumLifeSeconds + 1);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Platform>() != null)
        {
             ChangeColor();
        }
    }

    public IEnumerator DeactivateCube()
    {
        if(IsColorChanged == false)
            yield return null;

        yield return new WaitForSeconds(DelayActivity);

        print("deactiated");
        IsDeactivated = true;
    }

    public void SetActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }

    public void ChangeColor()
    {
        _colorChanger.ChangeColor(_colorToChange);

        IsColorChanged = !IsColorChanged;
    } 
}
