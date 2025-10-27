using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerCarControl : MonoBehaviour
{
    [Header("Wheels collider")] // it gives the header in the inspector
    public WheelCollider frontLeftWheelCollider;  // referecne to the wheel colliders
    public WheelCollider frontRightWheelCollider; // referecne to the wheel colliders
    public WheelCollider backLeftWheelCollider;   // referecne to the wheel colliders
    public WheelCollider backRightWheelCollider;  // referecne to the wheel colliders

    [Header("Wheels Transform")]
    public Transform frontRightWheelTransorm; // referecne to the wheel transformers
    public Transform frontLeftWheelTransorm;  // referecne to the wheel transformers
    public Transform backRightWheelTransorm;  // referecne to the wheel transformers
    public Transform backLeftWheelTransorm;  // referecne to the wheel transformers

    [Header(" Car Engine")]
    public float AccelerationForce = 300f;
    public float breakForce = 3000f;
    private float presentAcceleration = 0f;
    private float presentBreakForce = 0f;

    [Header("Car Steering")]
    public float WheelsTorque = 35; // wheel speed
    private float presentTurnAngle = 0f; // wheel  turn speed and turn angle 

    [Header("Car Sounds")]
    public AudioSource audioSource;
    public AudioClip accelarationSound;
    public AudioClip slowAccelaratioAudioSound;
    public AudioClip stopSound;

    private void Update()
    {
        MoveCar();          // cAlling Move Car function  to move the car in vertical axis
        CarSteering();      // cAlling Move Car function  to move the car in horizantal axis
        //applyBreaks();      // calling breaking system for  the  car
    }

    private void MoveCar()
    {
        //FWD vehicle   
        frontLeftWheelCollider.motorTorque = presentAcceleration; // it helps to  move the vehicle wheels motor torque is the inbuilt funciton comes with the  colliders. it  rotates the wheel  with the  speed of accelaratioForce which is stored in presentAccelaration
        frontRightWheelCollider.motorTorque = presentAcceleration;
        presentAcceleration = AccelerationForce * SimpleInput.GetAxis("Vertical"); //  helps to  move car in  vertical axis using simple input system

        if(presentAcceleration > 0)
        {
            audioSource.PlayOneShot(accelarationSound, 0.2f);
        }
        else if (presentAcceleration < 0)
        {
            audioSource.PlayOneShot(slowAccelaratioAudioSound, 0.2f);
        }
        else if (presentAcceleration == 0)
        {
            audioSource.PlayOneShot(slowAccelaratioAudioSound, 0.1f);
        }
    }

    private void CarSteering()
    {
        presentTurnAngle = WheelsTorque * SimpleInput.GetAxis("Horizontal"); // helps to  turn the car with  speed of wheels torque. using simple input systems
        frontLeftWheelCollider.steerAngle = presentTurnAngle; // steerAngle is  the built in method to turn the car direction
        frontRightWheelCollider.steerAngle = presentTurnAngle;


        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransorm);
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransorm);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransorm);
        SteeringWheels(backRightWheelCollider, backRightWheelTransorm);


    }
    void SteeringWheels(WheelCollider WC, Transform WT) // method to rotate the  wheels
    {
        Vector3 position; // Holds 3D position data (x, y, z).
        Quaternion rotation; //Represents rotation in 3D space

        WC.GetWorldPose(out position, out rotation); //GetWorldPose used to retrieve the world-space position and rotation of a specific component/object
        // out position, out rotation method output the  calculated position and rotation values  into the variables  
        WT.position = position;
        WT.rotation = rotation;
    }

    public void applyBreaks() // breaking system for the car
    {

        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        presentBreakForce = breakForce;
        //    }
        //    else
        //    {
        //        presentBreakForce = 0f; 
        //    }
        //frontLeftWheelCollider.brakeTorque = presentBreakForce;
        //frontRightWheelCollider.brakeTorque = presentBreakForce;
        //backLeftWheelCollider.brakeTorque = presentBreakForce;
        //backRightWheelCollider.brakeTorque = presentBreakForce;

        StartCoroutine(carBreaks()); // calling the breaking  function
    }
     IEnumerator carBreaks()
    {
        presentBreakForce = breakForce;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;

        yield return new WaitForSeconds(2f);

        presentBreakForce = 0f;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;

    }
}


