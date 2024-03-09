using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    private float rotationSpeed = 500.0f;
    private float currentRotationX = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
            CamOrbit();
    }


    private void CamOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            // Rotate around the x-axis
            currentRotationX -= verticalInput;
            currentRotationX = Mathf.Clamp(currentRotationX, 15f, 70f);
            transform.localRotation = Quaternion.Euler(currentRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);

            // Rotate around the y-axis
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }
}