using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _minInaccuracy = 0.4f;

    private Transform _targetPoint;
    private int _currentPointIndex = 0;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _targetPoint = _waypoints[_currentPointIndex].transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_targetPoint.position - transform.position).normalized;

        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);

        if (Vector2.Distance(transform.position, _targetPoint.position) < _minInaccuracy)
        {
            _currentPointIndex = ++_currentPointIndex % _waypoints.Length;
            _targetPoint = _waypoints[_currentPointIndex].transform;
        }
    }
}