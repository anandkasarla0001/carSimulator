using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//--------------------------------------TO SHOW  WAYPOINT EDITOR TOOLS IN MENU PANEL -----------------------------------------------
public class wayPointManagerWindow : EditorWindow
{
   
    [MenuItem("Window/Waypoints Editor tools")]
    public static void ShowWindow()
    {
        GetWindow<wayPointManagerWindow>("Waypoints Editor tools");
    }
    public Transform waypointOrigin; // parent for the  other way points

    private void OnGUI() 
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));
        if(waypointOrigin == null)
        {
            EditorGUILayout.HelpBox("please assign the waypoint transform.",MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }
            obj.ApplyModifiedProperties();
    }
    void CreateButtons()
    {
        if (GUILayout.Button("Create waypoint"))
        {
            CreateWaypoint();
        }
    }
    void CreateWaypoint()
    {
        GameObject waypointobj = new GameObject("waypoint" + waypointOrigin.childCount , typeof(wayPoint));
        waypointobj.transform.SetParent(waypointOrigin,false);

        wayPoint wayPoint = waypointobj.GetComponent<wayPoint>();

        if(waypointOrigin.childCount > 1) // helps to check the child more than 1
        {
            wayPoint.previousWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount-2).GetComponent<wayPoint>();
            wayPoint.previousWaypoint.nextWaypoint = wayPoint;

            wayPoint.transform.position = wayPoint.previousWaypoint.transform.position;
            wayPoint.transform.forward = wayPoint.previousWaypoint.transform.forward;
        }
        Selection.activeGameObject = wayPoint.gameObject;
    }
}
