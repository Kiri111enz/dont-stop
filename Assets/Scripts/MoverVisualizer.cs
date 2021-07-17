using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverVisualizer : MonoBehaviour
{
    private Mover _mover;
    
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private Animator _animator;
    
    [SerializeField] private bool _facingRight = true;
    private SpriteRenderer _spriteRenderer;

    private void OnMoverDirectionChanged(Direction newDirection)
    {
        if (newDirection == Direction.Left && _facingRight ||
            newDirection == Direction.Right && _facingRight == false)
            Flip();
        
        _animator.SetBool(IsMoving, newDirection != Direction.None);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _facingRight = !_facingRight;
    }
    
    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() => _mover.DirectionChanged += OnMoverDirectionChanged;
    
    private void OnDisable() => _mover.DirectionChanged -= OnMoverDirectionChanged;
}
