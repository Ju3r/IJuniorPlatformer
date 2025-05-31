using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _minInaccuracy = 0.4f;

    private EnemyMover _mover;
    private Transform _targetPoint;
    private int _currentPointIndex = 0;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        _targetPoint = _waypoints[_currentPointIndex].transform;
    }

    public void Patrol()
    {
        Vector2 direction = (_targetPoint.position - transform.position).normalized;

        if (Vector2.Distance(transform.position, _targetPoint.position) < _minInaccuracy)
        {
            _currentPointIndex = ++_currentPointIndex % _waypoints.Length;
            _targetPoint = _waypoints[_currentPointIndex].transform;
        }

        _mover.Move(direction.x);
    }
}