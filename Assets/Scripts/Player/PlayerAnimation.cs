using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string _speedParametr = "Speed";

    [SerializeField] private Animator _animator;

    private int _speedHash = Animator.StringToHash(_speedParametr);

    public void SetSpeed(float value)
    {
        _animator.SetFloat(_speedHash, value);
    }
}