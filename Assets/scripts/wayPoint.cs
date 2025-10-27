using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPoint : MonoBehaviour
{
    //----------------------------- AI  CAR PATH USING WAY POINTS---------------------------------  


    [Header("WayPoint Status")] //Adds a label inside the Inspector to organize variables visually.

    public wayPoint previousWaypoint;
    public wayPoint nextWaypoint;

    [Range(0f, 5f)]

    public float waypointWidth = 1f;

    public Vector3 GetPosition()  // Used by AI or moving objects to get a target point on this waypoint.
    {

        // transform.position → The center position of this waypoint in the scene.
        // transform.right → The local right direction of the waypoint (the red arrow in Unity’s scene view).
        // waypointWidth / 2 → Half the width to go equally on both sides of the waypoint.
        // minBound = position to the right of the waypoint.
        // maxBound = position to the left of the waypoint.


        Vector3 minBound = transform.position + transform.right * waypointWidth / 2;
        Vector3 maxBound = transform.position - transform.right * waypointWidth / 2;

        // Vector3.Lerp(a, b, t) → Returns a point between a and b, where t is the interpolation factor:
        //t = 0 → returns a (minBound)
        //t = 1 → returns b (maxBound)
        //t = 0.5 → returns the midpoint

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));  // Picks a random point between left and right bounds for smooth variation.
    }
}
