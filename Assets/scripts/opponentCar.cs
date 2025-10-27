using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turningSpeed = 50f;
    public float breakSpeed = 12f;

    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;

    private void Update() // inprder to move the  opponent  call we have to call the  drive() method in update function
    {
        Drive(); // calling opponent car drive function
    }

    public void Drive()
    {
        if (transform.position != destination) // it means the oppponent car doesnt reachh the destination,
        {
            Vector3 destinationDirection = destination - transform.position; // tells your GameObject which direction to move or look in order to reach the target.
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= breakSpeed) // helps to  rotate the vehicle  to move  towards the destination
            {
                //basically  known as steering as vehicle
                destinationReached = false;
                Quaternion targerRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targerRotation, turningSpeed * Time.deltaTime);

                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);//MOVE VEHICLE TOWARDS DESTINATION
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }

}
