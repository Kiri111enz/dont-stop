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
        // TODO: check if meteor hits player and ...
        
        Destroy(gameObject);
    }
}
