using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speedX = 0.5f;

    private Flipper _flipper;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(
                _speedX * direction * ConstantData.SpeedCoefficient, 
                _rigidbody.velocity.y);

        _flipper.Flip(direction);
    }
}