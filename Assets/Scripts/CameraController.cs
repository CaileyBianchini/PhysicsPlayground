using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 30.0f;
    public float sensitivity = 5.0f;
    public bool invertY = false;

    private void Update()
    {
        //rotate and move camera
        if(Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            Vector2 mouse;
            mouse.y = Input.GetAxis("Mouse Y") * (invertY ? 1.0f : -1.0f);
            mouse.x = Input.GetAxis("Mouse X");
            //look up and down by rotating around X-axis
            angles.x = Mathf.Clamp(angles.x + mouse.x * sensitivity * Time.deltaTime, 0.0f, 70.0f);
            //look left and right by rotating around the Y-axis
            angles.y += mouse.y * sensitivity;
            //set the angles
            transform.eulerAngles = angles;
        }
        //move with camera
        transform.position = target.position + (distanceFromTarget * -transform.forward);

        //look at the target
        //transform.LookAt(target);
    }
}
