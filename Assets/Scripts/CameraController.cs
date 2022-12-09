using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceUp;
    public float distanceBack;
    public float minimunHeight;
    private Vector3 positionVelocity;

    private void FixedUpdate()
    {
        Vector3 newPosition = target.position + (target.forward * distanceBack);
        newPosition.y = Mathf.Max(newPosition.y + distanceUp, minimunHeight);

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, 0.18f);

        Vector3 focalPoint = target.position + (target.forward * 5);
        transform.LookAt(focalPoint);
    }
}
