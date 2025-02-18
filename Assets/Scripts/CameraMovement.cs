using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int _currentPointIndex;
    [SerializeField] private List<Transform> _points;

    private void OnValidate()
    {
        SetIndex(Mathf.Clamp(_currentPointIndex, 0 , _points.Count - 1));
    }
    
    public void Move(int direction)
    {
        if ((direction != -1) && (direction != 1))
        {
            throw new ArgumentOutOfRangeException(nameof(direction) + direction);
        }
    
        int index = (_currentPointIndex + direction < 0) ? _points.Count - 1 
            : (_currentPointIndex + direction) % _points.Count;
    
        SetIndex(index);
    }
    
    private void SetIndex(int index)
    {
        if ((index < 0) || (index >= _points.Count))
        {
            throw new IndexOutOfRangeException(nameof(index) + index);
        }
    
        _currentPointIndex = index;
        
        transform.position = _points[_currentPointIndex].position;
        transform.rotation = _points[_currentPointIndex].rotation;
    }
}
