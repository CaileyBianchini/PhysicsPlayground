using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 10.0f;
    public float sensitivity = 5.0f;
    public bool invertY = false;
    public float relaxSpeed = 5.0f;

    private float currentDistance;

    private void Start()
    {
        currentDistance = maxDistance;
    }

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
            angles.x += mouse.x * sensitivity;
            angles.x = Mathf.Clamp(angles.x, 0.0f, 90.0f);
            //look left and right by rotating around the Y-axis
            angles.y += mouse.y * sensitivity;
            //set the angles
            transform.eulerAngles = angles;
        }
        //move with camera
        RaycastHit hit;
        if(Physics.Raycast(target.position, - transform.forward, out hit, maxDistance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            currentDistance = Mathf.MoveTowards(currentDistance, maxDistance, relaxSpeed * Time.deltaTime);
        }
        transform.position = target.position + (-transform.forward * currentDistance);

        //look at the target
        //transform.LookAt(target);
    }
}
