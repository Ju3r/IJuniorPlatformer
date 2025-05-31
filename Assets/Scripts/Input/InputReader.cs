using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isJump;
    private KeyCode _jumpKey = KeyCode.W;
    public float Direction {  get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(ConstantData.HorizontalAxis);

        if (Input.GetKeyDown(_jumpKey))
        {
            _isJump = true;
        }
    }

    public bool GetIsJump()
    {  
        bool isJump = _isJump;
        _isJump = false;

        return isJump; 
    }
}
