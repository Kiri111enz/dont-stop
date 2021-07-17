using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicalMover : Mover
{
    [SerializeField] private float _speed = 10;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speed * (int) Direction, _rigidbody.velocity.y);
    }
}
