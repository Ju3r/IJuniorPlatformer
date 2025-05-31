using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _lackOfMovement = 0f;

    public void Flip(float direction)
    {
        if (direction > _lackOfMovement)
            FlipToRight();
        else if (direction < _lackOfMovement)
            FlipToLeft();
    }

    private void FlipToRight()
    {
        float _turnRight = 0f;
        transform.rotation = Quaternion.Euler(0f, _turnRight, 0f);
    }

    private void FlipToLeft()
    {
        float _turnLeft = 180f;
        transform.rotation = Quaternion.Euler(0f, _turnLeft, 0f);
    }
}
