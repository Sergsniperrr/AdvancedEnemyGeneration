using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private readonly float _speed = 4;

    private int _currentPoint = 0;

    void Update()
    {
        if (transform.position == _waypoints[_currentPoint].position)
        {
            _currentPoint = (_currentPoint + 1) % _waypoints.Length;
            transform.LookAt(_waypoints[_currentPoint]);
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentPoint].position, _speed * Time.deltaTime);
    }
}