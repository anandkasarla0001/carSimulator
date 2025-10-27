using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics.Eventing.Reader;

[InitializeOnLoad()]

public class wayPointEditor 
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)] // helps to draw the gizmos of selected game object
    public  static void OnDrawsceneGizmos(wayPoint wayPoint , GizmoType gizmoType) // passsing gizmos parameter
    {
        if ((gizmoType & GizmoType.Selected)!=0) // it means the waypoint is selected
        {
                Gizmos.color = Color.blue; // helps to recognise the waypoint easily
        }
        else
        {
            Gizmos.color = Color.blue * 0.5f ; // adding the color intenstiy by multiplying the 05f
        }
        Gizmos.DrawSphere(wayPoint.transform.position, 0.1f); // helps to draw  the gizmos from  the center and it gives the size of Gimos
        Gizmos.color = Color.white;
        Gizmos.DrawLine(wayPoint.transform.position + (wayPoint.transform.right * wayPoint.waypointWidth / 2f) , wayPoint.transform.position - (wayPoint.transform.right * wayPoint.waypointWidth / 2f )); // helps to  draw line  and measures the waypoint widht


        //---------------------------------------------------DRAWING THE LINE FROM PREVIOUS WAYPOINT TO  THE NEXT WAYPOINT--------------------------------------------------------------------------------
        if (wayPoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = wayPoint.transform.right * wayPoint.waypointWidth / 2f ; // give the position of the current waypoint
            Vector3 offsetTo = wayPoint.previousWaypoint.transform.right * wayPoint.previousWaypoint.waypointWidth / 2f; // it takes the previous waypoint as reference and draw the line to current wayPoint 
            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.previousWaypoint.transform.position + offsetTo);
        }
        //---------------------------------------------------DRAWING THE LINE FROM PREVIOUS WAYPOINT TO  THE NEXT WAYPOINT--------------------------------------------------------------------------------
        if (wayPoint.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = wayPoint.transform.right * -wayPoint.waypointWidth / 2f; // give the position of the current waypoint
            Vector3 offsetTo = wayPoint.previousWaypoint.transform.right * -wayPoint.previousWaypoint.waypointWidth / 2f; // it takes the previous waypoint as reference and draw the line to current wayPoint 
            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.previousWaypoint.transform.position + offsetTo);
        }
    }
}
