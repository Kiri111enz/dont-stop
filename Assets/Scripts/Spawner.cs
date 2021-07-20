using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("GameObject to spawn")]
    [SerializeField] private GameObject _prefab;

    [Header("Timing settings")]
    [SerializeField] private float _delay;
    [SerializeField] private float _delayStep;
    [SerializeField] private float _minimalDelay;

    [Header("Area settings (in world coordinates)")] 
    [SerializeField] private Vector2 minPoint;
    [SerializeField] private Vector2 maxPoint;

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (_delay < _minimalDelay)
                _delay = _minimalDelay;
            
            yield return new WaitForSeconds(_delay);
            Spawn();
            
            if (_delay == _minimalDelay)
                continue;
            
            _delay -= _delayStep;
        }
    }

    private void Spawn()
    {
        var position = new Vector3(Random.Range(minPoint.x, maxPoint.x), Random.Range(minPoint.y, maxPoint.y));
        Instantiate(_prefab, position, Quaternion.identity);
    }

    private void Awake() => StartCoroutine(SpawnLoop());

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(minPoint, 0.5f);
        Gizmos.DrawSphere(maxPoint, 0.5f);

        Gizmos.DrawWireCube((minPoint + maxPoint) / 2, maxPoint - minPoint);
    }
}
