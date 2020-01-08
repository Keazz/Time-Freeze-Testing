using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    private const float SCROLL_MIN = -15.0f;
    private const float SCROLL_MAX = -5.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = -10f;
    private float currentX = 0f;
    private float currentY = 0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;

        Cursor.visible = false;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
        distance += Input.GetAxis("Scroll") * 3;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        distance = Mathf.Clamp(distance, SCROLL_MIN, SCROLL_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
