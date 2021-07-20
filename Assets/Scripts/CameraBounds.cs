using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    [SerializeField] private bool _left = true;
    [SerializeField] private bool _top = true;
    [SerializeField] private bool _right = true;
    [SerializeField] private bool _bottom = true;

    private Camera _camera;

    private void CreateBounds()
    {
        var orthographicSize = _camera.orthographicSize;
        var cameraSize = new Vector2(orthographicSize * _camera.aspect, orthographicSize);
        
        var points = new[]
        {-cameraSize, new Vector2(-cameraSize.x, cameraSize.y), cameraSize, new Vector2(cameraSize.x, -cameraSize.y)};

        if (_left)
            AddBound(new [] {points[0], points[1]});
        
        if (_top)
            AddBound(new [] {points[1], points[2]});
        
        if (_right)
            AddBound(new [] {points[2], points[3]});
        
        if (_bottom)
            AddBound(new [] {points[3], points[0]});
    }
    
    private void AddBound(Vector2[] points)
    {
        gameObject.AddComponent<EdgeCollider2D>().points = points;
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame(); // waiting for camera to be adjusted by pixel perfect camera/etc.
        
        CreateBounds();
        Destroy(this);
    }
}
