using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TransparencyChanger))]
public class Bomb : MonoBehaviour, IPoolable
{
    [SerializeField] private int _minimumLifeTime;
    [SerializeField] private int _maximumLifeTime;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionPrefab;

    private int _lifeTime;
    private bool _isActive;

    private TransparencyChanger _transparencyChanger;

    private void Awake()
    {
        _transparencyChanger = GetComponent<TransparencyChanger>();
    }

    private void OnEnable()
    {
        _isActive = true;
        _lifeTime = Random.Range(_minimumLifeTime, _maximumLifeTime + 1);
        _transparencyChanger.Dissapear(_lifeTime);
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_lifeTime);

        Explode();
        _isActive = false;
    }

    private void Explode()
    {
        var currentPosition = transform.position;

        var hits = Physics.OverlapSphere(currentPosition, _explosionRadius);

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody == null)
                continue;

            Vector3 direction = (hit.transform.position - currentPosition).normalized;

            hit.attachedRigidbody.AddForce(direction * _explosionForce, ForceMode.Impulse);
        }

        Instantiate(_explosionPrefab, transform.position, transform.rotation);
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public void SetActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }
}
