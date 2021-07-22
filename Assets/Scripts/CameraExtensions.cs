using UnityEngine;

public static class CameraExtensions
{
    public static float GetViewportWidthInUnits(this Camera camera) => camera.orthographicSize * camera.aspect * 2;
}
