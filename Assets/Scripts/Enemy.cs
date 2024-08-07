using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _currentLifeTime;

    private readonly float _speed = 3;
    private readonly float _maxLifeTime = 20;
    private readonly float _delay = 1f;

    private Transform _target;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        _currentLifeTime = _maxLifeTime;
        StartCoroutine(LifeCounter());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);
    }

    private void CountDown()
    {
        _currentLifeTime--;
        if (_currentLifeTime <= 0)
            Destroy(gameObject);
    }

    private IEnumerator LifeCounter()
    {
        bool isLiving = true;

        while (isLiving)
        {
            CountDown();

            yield return _wait;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
