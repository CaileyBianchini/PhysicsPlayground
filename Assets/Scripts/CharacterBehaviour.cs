using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravityModifier = 1.0f;
    public float airControl = 1.0f;
    public float jumpForce = 10;

    public bool _isGrounded = false;

    public Camera playerCamera;
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

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;

        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        _desiredGroundVelocity = (_desiredGroundVelocity.x * cameraRight + _desiredGroundVelocity.z * cameraForward);

        //get jump input
        _isJumpedDesired = Input.GetButtonDown("Jump");

        //set movement magnitude
        _desiredGroundVelocity.Normalize();
        _desiredGroundVelocity *= speed;

        //check foe ground 
        _isGrounded = _controller.isGrounded;

        if (_isJumpedDesired)
        {
            _desiredAirVelocity.y = jumpForce;
            _isJumpedDesired = !_isJumpedDesired;
        }

        //step on ground
        if (_isGrounded && _desiredAirVelocity.y < 0.0f)
        {
            _desiredAirVelocity.y = 0.0f;
        }

        //add air velocity
        _desiredAirVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //apply gravity
        _desiredGroundVelocity += _desiredAirVelocity;

        //move
        _controller.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.deltaTime);
    }
}
