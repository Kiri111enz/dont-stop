using UnityEngine;

public enum Direction
{
    Left = -1, None = 0, Right = 1
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed = 10;
    [SerializeField] private bool _facingRight = true;
    
    public Direction Direction
    {
        get => _direction;
        set
        {
            if (value == Direction.Left && _facingRight ||
                value == Direction.Right && _facingRight == false)
                Flip();

            _direction = value;
            _animator.SetBool(IsMoving, _direction != Direction.None);
        }
    }
    private Direction _direction;
    
    private Rigidbody2D _rigidbody;

    private Animator _animator;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Flip()
    {
        var moverTransform = transform;
        var scale = moverTransform.localScale;
        scale.x *= -1;
        moverTransform.localScale = scale;

        _facingRight = !_facingRight;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speed * (int) Direction, _rigidbody.velocity.y);
    }
}
