using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawerScript : MonoBehaviour {

    private LineRenderer PathDrawer;

	// Use this for initialization
	void Start () {
        PathDrawer = GetComponent<LineRenderer>();
        PathDrawer.material.color = Color.green;
	}

    //Draws a line between all positions of the waypoints in the current waypointlist
    public void DrawPath(List<GameObject> wayPoints)
    {
        PathDrawer.positionCount = wayPoints.Count;
        for (int i = 0; i < wayPoints.Count; i++)
        {
            PathDrawer.SetPosition(i, wayPoints[i].transform.position);
        }
    }
}
