using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int _step = 20;
    
    public void Move(int direction)
    {
        transform.position += Vector3.right * _step * direction;
    }
}
