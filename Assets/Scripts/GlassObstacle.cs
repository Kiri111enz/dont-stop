using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GlassObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Alive alive))
            alive.Die();
        
        Destroy(gameObject);
    }
}
