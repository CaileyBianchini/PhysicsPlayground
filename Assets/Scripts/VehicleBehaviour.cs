using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    public HingeJoint frontLeft;
    public HingeJoint frontRight;
    public HingeJoint backLeft;
    public HingeJoint backRight;

    public int motorValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        frontLeft = GetComponent<HingeJoint>();
        frontRight = GetComponent<HingeJoint>();
        backLeft = GetComponent<HingeJoint>();
        backRight = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //forward
        if (Input.GetButtonDown("w"))
        {
            //both fronts
            JointMotor motor1 = frontLeft.motor;
            motor1.targetVelocity = motorValue;
            motor1.force = motorValue;
            JointMotor motor2 = frontRight.motor;
            motor2.targetVelocity = motorValue;
            motor2.force = motorValue;
            frontLeft.motor = motor1;
            frontRight.motor = motor2;
        }
        //backward
        else if (Input.GetButtonDown("s"))
        {
            //both backs
            JointMotor motor1 = backLeft.motor;
            motor1.targetVelocity = motorValue;
            motor1.force = motorValue;
            JointMotor motor2 = backRight.motor;
            motor2.targetVelocity = motorValue;
            motor2.force = motorValue;
            backLeft.motor = motor1;
            backRight.motor = motor2;
        }
        //left
        else if (Input.GetButtonDown("a"))
        {
            //front right
            JointMotor motor = frontRight.motor;
            motor.targetVelocity = motorValue;
            motor.force = motorValue;
            frontRight.motor = motor;
        }
        //right
        else if (Input.GetButtonDown("d"))
        {
            //front left
            JointMotor motor = frontLeft.motor;
            motor.targetVelocity = motorValue;
            motor.force = motorValue;
            frontLeft.motor = motor;
        }
    }
}
