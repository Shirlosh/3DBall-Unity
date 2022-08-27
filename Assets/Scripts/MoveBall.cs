using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveBall : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public bool grounded;
    public float accelX = 1.0f;
    public float accelY = 1.0f;
    public float maxSpeed = 50.0f;
    public Transform playerCam;
    [SerializeField] private float moveForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get player inputs
        if (grounded == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            //Change inputs from world xyz to camera xyz
            Vector3 camF = playerCam.forward;
            Vector3 camR = playerCam.right;
            camF.y = 0.0f;
            camR.y = 0.0f;
            camF = camF.normalized;
            camR = camR.normalized;

            //Add force to the ball based on camera position
            Vector3 movement = ((camF * vertical * accelX) + (camR * horizontal * accelY));
            _rigidbody.AddForce(movement);

            //Speed limit
            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }
        }
    }
}