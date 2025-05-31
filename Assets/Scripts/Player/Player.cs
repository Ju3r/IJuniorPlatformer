using UnityEngine;

[RequireComponent (typeof(InputReader), typeof(PlayerMover), typeof(PlayerAnimation))]
[RequireComponent (typeof(PlayerCollector))]
public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector; 
    [SerializeField] private PlayerScore _score;

    private InputReader _inputReader;
    private PlayerMover _mover;
    private PlayerAnimation _animation;
    private PlayerCollector _collector;

    private float _lackOfMovement = 0;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _animation = GetComponent<PlayerAnimation>();
        _collector = GetComponent<PlayerCollector>();
    }

    private void OnEnable()
    {
        _collector.CoinCollected += OnCoinCollected;
        _inputReader.OnJumpPressed += OnJumpPressed;
    }

    private void OnDisable()
    {
        _collector.CoinCollected -= OnCoinCollected;
        _inputReader.OnJumpPressed -= OnJumpPressed;
    }

    private void Update()
    {
        _animation.SetSpeed(Mathf.Abs(_inputReader.Direction));
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != _lackOfMovement)
            _mover.Move(_inputReader.Direction);
    }

    public void OnCoinCollected(float value)
    {
        _score.Add(value);
    }

    private void OnJumpPressed()
    {
        if (_groundDetector.IsGround)
            _mover.Jump();
    }
}