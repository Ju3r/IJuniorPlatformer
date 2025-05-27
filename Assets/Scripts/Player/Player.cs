using UnityEngine;

[RequireComponent (typeof(InputReader), typeof(PlayerMover), typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector; 
    [SerializeField] private PlayerScore _score;

    private InputReader _inputReader;
    private PlayerMover _mover;
    private PlayerAnimation _animation;

    private float _lackOfMovement = 0;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _animation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        _animation.SetSpeed(Mathf.Abs(_inputReader.Direction));
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != _lackOfMovement)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();
    }

    public void CollectCoin(float value)
    {
        _score.Add(value);
    }
}