using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMotion : MonoBehaviour
{
    [SerializeField] private Camera cam;

    // Update is called once per frame
    void Update()
    {
        Vector3 cam_pos = cam.transform.position; 
        transform.position = new Vector3(cam_pos.x, cam_pos.y, cam_pos.z+5);
    }
}
