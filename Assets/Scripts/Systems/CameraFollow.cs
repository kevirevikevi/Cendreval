using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float pixelsPerUnit = 32f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // Snap à la grille pixel
        desiredPosition.x = Mathf.Round(desiredPosition.x * pixelsPerUnit) / pixelsPerUnit;
        desiredPosition.y = Mathf.Round(desiredPosition.y * pixelsPerUnit) / pixelsPerUnit;
        desiredPosition.z = offset.z;

        transform.position = desiredPosition;
    }
}