using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravityModifier = 1.0f;
    public float jumpForce = 10;

    private CharacterController _controller;

    private Vector3 _desiredGroundVelocity;
    private Vector3 _desiredAirVelocity;
    private bool _isJumpedDesired;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //get movement input
        _desiredGroundVelocity.x = Input.GetAxis("Horizontal");
        _desiredGroundVelocity.y = 0.0f;
        _desiredGroundVelocity.z = Input.GetAxis("Vertical");

        //get jump input
        _isJumpedDesired = Input.GetButtonDown("Jump");

        //set movement magnitude
        _desiredGroundVelocity.Normalize();
        _desiredGroundVelocity *= speed;

        if (_isJumpedDesired)
        {
            _desiredGroundVelocity.y = jumpForce;
            _isJumpedDesired = !_isJumpedDesired;
        }

        //apply gravity
        _desiredGroundVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //move
        _controller.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.deltaTime);
    }
}
