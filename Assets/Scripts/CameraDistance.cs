using UnityEngine;
using System;


public class CameraDistance : MonoBehaviour
{
    private float zoomSpeed = 20f;
    public GameObject focpoint;

    private double lastdist = 0f;
    private double dist = 0f;
    private bool isTouching2 = false;


    void Start()
    {
        focpoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        if (Input.touchCount <= 1)
        {
            isTouching2 = false;
        }

        if (Input.touchCount >= 2)
        {
            Vector2 touch1 = Input.GetTouch(0).position;
            Vector2 touch2 = Input.GetTouch(1).position;

            if (!isTouching2)
            {
                isTouching2 = true;
                lastdist = Vector2.Distance(touch1, touch2);
            }
            else
            {
                dist = Vector2.Distance(touch1, touch2);
                float zoomAmount = (float)(dist - lastdist) * Time.deltaTime * zoomSpeed;

                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * zoomAmount, Time.deltaTime);
                transform.LookAt(focpoint.transform);

                lastdist = dist;
            }
        }
    }
}