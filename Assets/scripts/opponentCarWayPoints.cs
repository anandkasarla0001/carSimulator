using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentCarWayPoints : MonoBehaviour
{
    [Header("opponent Car")]
    public opponentCar opponentCar;
    public wayPoint currentWayPoint;
    private void Awake()
    {
        opponentCar = GetComponent<opponentCar>();
    }
    private void Start()
    {
        opponentCar.LocateDestination(currentWayPoint.GetPosition()); //giving destination to the cars
    }
    private void Update()
    {
        if(opponentCar.destinationReached)
        {
            currentWayPoint = currentWayPoint.nextWaypoint;
            opponentCar.LocateDestination(currentWayPoint.GetPosition()); // to move vehicle to next way point
        }
    }
}
