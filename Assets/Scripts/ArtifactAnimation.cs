using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateArtifact : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private float amplitude = 0.4f;
    private float frequency = 0.50f;
    private float initialHeight = 1f;



    void Start()
    {
        initialHeight = transform.position.y + 1f;
    }


    void Update()
    {
        RotateAndFloat();
    }


    private void RotateAndFloat()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, initialHeight + (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude), transform.position.z);
    }


    private void OnMouseDown() 
    {
        Debug.Log("Test");
    }
}
