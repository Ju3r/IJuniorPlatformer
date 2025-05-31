using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour 
{
    private EnemyMover _mover;
    private EnemyPatrol _patrol;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _patrol = GetComponent<EnemyPatrol>();
    }

    private void FixedUpdate()
    {
        _patrol.Patrol();
    }
}