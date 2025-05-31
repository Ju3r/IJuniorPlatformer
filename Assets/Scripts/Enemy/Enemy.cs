using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour 
{
    private EnemyPatrol _patrol;

    private void Awake()
    {
        _patrol = GetComponent<EnemyPatrol>();
    }

    private void FixedUpdate()
    {
        _patrol.Patrol();
    }
}