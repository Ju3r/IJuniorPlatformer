using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _speedHash = Animator.StringToHash(ConstantData.SpeedParametr);

    public void SetSpeed(float value)
    {
        _animator.SetFloat(_speedHash, value);
    }
}