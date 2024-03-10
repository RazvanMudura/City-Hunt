using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    private float rotationSpeed = 10.0f;
    private float currentRotationX = 15f;
    private Vector2 touchStart;
    private bool isTouching = false;

    
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                Vector2 touchDelta = touch.position - touchStart;

                float verticalInput = -touchDelta.y * rotationSpeed * Time.deltaTime;
                float horizontalInput = touchDelta.x * rotationSpeed * Time.deltaTime;

                // Rotate around the x-axis
                currentRotationX += verticalInput;
                currentRotationX = Mathf.Clamp(currentRotationX, 15f, 75f);
                transform.localRotation = Quaternion.Euler(currentRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);

                // Rotate around the y-axis
                transform.Rotate(Vector3.up, horizontalInput, Space.World);

                touchStart = touch.position;
            }
        }
        else if (Input.touchCount == 0)
        {
            isTouching = false;
        }
    }
}