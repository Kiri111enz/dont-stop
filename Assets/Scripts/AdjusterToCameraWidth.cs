using System.Collections;
using UnityEngine;

public class AdjusterToCameraWidth : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] _objectsToAdjust;
    
    private float _initialViewportWidth;

    private void AdjustObjects()
    {
        var viewportWidthCoeff = _camera.GetViewportWidthInUnits() / _initialViewportWidth;
        
        foreach (var adjustable in _objectsToAdjust)
        {
            var localScale = adjustable.transform.localScale;
            localScale.x *= viewportWidthCoeff;
            adjustable.transform.localScale = localScale;
        }
    }

    private IEnumerator Start()
    {
        _initialViewportWidth = _camera.GetViewportWidthInUnits();
        
        yield return new WaitForEndOfFrame(); // waiting for camera to be adjusted by pixel perfect camera/etc.
        AdjustObjects();
        Destroy(this);
    }
}
