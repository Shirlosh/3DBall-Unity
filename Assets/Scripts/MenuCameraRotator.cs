using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraRotator : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] [Range(0, 360)] private int maxRotationInOneSwipe = 180;
    private Vector3 _previousPosition;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = _previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * maxRotationInOneSwipe; // camera moves horizontally
            float rotationAroundXAxis = direction.y * maxRotationInOneSwipe; // camera moves vertically

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis,
                Space.World); // <— This is what makes it work!


            _previousPosition = newPosition;
        }
    }
}