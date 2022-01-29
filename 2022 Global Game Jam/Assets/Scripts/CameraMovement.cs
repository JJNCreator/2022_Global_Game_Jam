using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 3.0f;
    public float distanceFromTarget = 3.0f;

    private float rotationY;
    private float rotationX;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;
    private float smoothTime = 0.2f;

    private Transform transformCache;

    private void Awake()
    {
        transformCache = transform;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX += mouseY;

        rotationX = Mathf.Clamp(rotationX, -40f, 40f);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transformCache.localEulerAngles = currentRotation;

        if(target != null)
        {
            transformCache.position = target.position - transformCache.forward * distanceFromTarget;
        }
    }
}
