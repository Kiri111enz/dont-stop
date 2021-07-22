using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Collider2D))]
public class Meteor : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _mover.Direction = Direction.Left;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Alive alive))
            alive.Die();
        
        Destroy(gameObject);
    }
}
