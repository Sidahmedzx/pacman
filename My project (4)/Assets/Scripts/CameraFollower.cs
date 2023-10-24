using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target; // The player object to follow
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset; // Offset of the camera from the player

    public float sensitivity = 2.0f; // Mouse sensitivity for camera control
    public float maxYAngle = 80.0f; // Maximum angle the camera can look up and down

    private float rotationX = 0;

    void LateUpdate()
    {
        // Follow the player smoothly
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Call the Look method to control camera rotation
        Look();
    }

    void Look()
    {
        // Rotate the camera with mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

        transform.eulerAngles = new Vector3(rotationX, transform.eulerAngles.y + mouseX, 0);
    }
}
