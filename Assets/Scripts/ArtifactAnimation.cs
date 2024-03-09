using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArtifact : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private float amplitude = 2.0f;
    private float frequency = 0.50f;


    // Update is called once per frame
    void Update()
    {
        RotateAndFloat();
    }


    private void RotateAndFloat()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + 15, transform.position.z);
    }


    private void OnMouseDown() 
    {
        Debug.Log("Test");
    }
}
