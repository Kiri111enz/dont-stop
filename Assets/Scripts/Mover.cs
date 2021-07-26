using System;
using UnityEngine;

public enum Direction
{
    Left = -1, None = 0, Right = 1
}

public abstract class Mover : MonoBehaviour
{
    public float Speed
    {
        get => _speed = Mathf.Max(0, _speed);
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Speed), "Speed can't be negative!");

            _speed = value;
        }
    }
    [SerializeField] private float _speed;

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
    [SerializeField] private Direction _direction;
    
    public event Action<Direction> DirectionChanged;
}
