using UnityEngine;

public class Spawner : RepeaterWithDelay
{
    [Header("GameObject to spawn")]
    [SerializeField] private GameObject _prefab;
    
    private Vector2 MinPoint => transform.position - transform.localScale / 2;
    private Vector2 MaxPoint => transform.position + transform.localScale / 2;

    protected override void OnRepeat() => Spawn();
    
    private void Spawn()
    {
        var position = new Vector3(Random.Range(MinPoint.x, MaxPoint.x), Random.Range(MinPoint.y, MaxPoint.y));
        Instantiate(_prefab, position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(MinPoint, 0.5f);
        Gizmos.DrawSphere(MaxPoint, 0.5f);

        Gizmos.DrawWireCube((MinPoint + MaxPoint) / 2, MaxPoint - MinPoint);
    }
}
