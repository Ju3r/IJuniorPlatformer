using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SpeedCoefficient = 10;

    [SerializeField] private float _speedX = 1;
    [SerializeField] private float _jumpForce = 10;

    private Rigidbody2D _rigidbody;
    private bool _isTurnRight = true;
    private int _lackOfMovement = 0; 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * SpeedCoefficient * Time.fixedDeltaTime, _rigidbody.velocity.y);

        if ((direction > _lackOfMovement && _isTurnRight == false)
            || (direction < _lackOfMovement && _isTurnRight))
        {
            Flip();
        }
    }

    public void Jump()
    {
        int jumpX = 0;
        _rigidbody.AddForce( new Vector2(jumpX, _jumpForce));
    }

    private void Flip()
    {
        int inverse = -1;

        _isTurnRight = !_isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x *= inverse;
        transform.localScale = scale;
    }
}