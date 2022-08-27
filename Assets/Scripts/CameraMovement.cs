using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] [Range(0, 360)] private int maxRotationInOneSwipe = 180;
    private Vector3 previousPosition;

    private Vector3 _vector3;

    private void Start()
    {
        _vector3 = new Vector3(0, 1, -5);
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.position = target.transform.position + _vector3;
        // Rotate the camera every frame so it keeps looking at the target
        //cam.transform.LookAt(target.transform);
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;
            
            float rotationAroundYAxis = -direction.x * maxRotationInOneSwipe; // camera moves horizontally
            float rotationAroundXAxis = direction.y * maxRotationInOneSwipe; // camera moves vertically
            
            cam.transform.position = target.position;
            
            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            
            previousPosition = newPosition;
        }
        else
        {
            Vector3 newPosition = new Vector3(target.position.x, target.position.y + 5, target.position.z + 5);
            
            cam.transform.position = target.position;
            
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            
            previousPosition = newPosition;
        }
    }
}