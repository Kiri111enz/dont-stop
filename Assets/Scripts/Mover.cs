using System;
using UnityEngine;

public enum Direction
{
    Left = -1, None = 0, Right = 1
}

public abstract class Mover : MonoBehaviour
{
    public event Action<Direction> DirectionChanged;
    
    public Direction Direction
    {
        get => _direction;
        set
        {
            if (value == _direction)
                return;
            
            _direction = value;
            DirectionChanged?.Invoke(value);
        }
    }
    private Direction _direction;
}
