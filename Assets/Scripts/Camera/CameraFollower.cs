using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3 (0, 5, -7);
    [SerializeField] public Transform player;

    private void LateUpdate()
    {
        transform.position = player.position + _offset;
    }
}