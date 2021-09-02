using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravityModifier = 1.0f;
    public float airControl = 1.0f;
    public float jumpForce = 10;
    public bool faceWithCamera = true;

    private bool _isGrounded = false;

    public Camera playerCamera;
    private CharacterController _controller;
    [SerializeField]
    private Animator _animator;

    private Vector3 _desiredVelocity;
    private Vector3 _desiredAirVelocity;
    private bool _isJumpedDesired;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        //get movement input
        _desiredVelocity.x = Input.GetAxis("Horizontal"); //_desiredVelocity.x is inputRight
        _desiredVelocity.y = 0.0f;
        _desiredVelocity.z = Input.GetAxis("Vertical");//_desiredVelocity.y is inputForward

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;

        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        //find the desired velocity
        _desiredVelocity = (_desiredVelocity.x * cameraRight + _desiredVelocity.z * cameraForward);
        // or (cameraForward * inputForward) + (cameraRight * inputRight) inputs are the change for the 
        //"get movement input group"
        //horizontal is inputForward and vertical is inputRight 

        //get jump input
        _isJumpedDesired = Input.GetButtonDown("Jump");

        //set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //check for ground 
        _isGrounded = _controller.isGrounded;

        //update animations
        if (faceWithCamera)
        {
            transform.forward = cameraForward;
            _animator.SetFloat("Speed", _desiredVelocity.x);
            _animator.SetFloat("Direction", _desiredVelocity.z);
        }
        else
        {
            if(_desiredVelocity != Vector3.zero)
                transform.forward = _desiredVelocity.normalized;
            _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);
        }

        _animator.SetBool("Jump", !_isGrounded);

        //Update animations
        _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);

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
        _desiredVelocity += _desiredAirVelocity;

        //move
        _controller.Move((_desiredVelocity + _desiredAirVelocity) * Time.deltaTime);
    }
}
