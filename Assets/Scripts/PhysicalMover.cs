using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicalMover : Mover
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Speed * (int) Direction, _rigidbody.velocity.y);
    }
}
