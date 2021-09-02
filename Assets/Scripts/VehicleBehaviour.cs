using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    private CharacterController _controller;

    private Vector3 _desiredVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get movement input
        _desiredVelocity.x = Input.GetAxis("Horizontal"); //_desiredVelocity.x is inputRight
        _desiredVelocity.y = 0.0f;
        _desiredVelocity.z = Input.GetAxis("Vertical");//_desiredVelocity.y is inputForward

    }
}
