using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShipController : MonoBehaviour {

    public Camera mainCam;
    public NavMeshAgent playerAgent;
    private LineRenderer pathLineRenderer;
    public GameObject wayPointPrefab;
    private List<GameObject> wayPointList = new List<GameObject>();
    public GameObject wayPointPathDrawer;

    float wayPointDistance = 10f;
    bool startTurn = false;

    // Use this for initialization
    void Start () {
        mainCam = Camera.main;
        pathLineRenderer = GetComponent<LineRenderer>();
	}
	
	void Update () {

        //Destroys all current waypoints and clears the list, then spawns and adds a waypoint. Waypoint
        if (Input.GetMouseButtonDown(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            foreach (GameObject GO in wayPointList)
            {
                Destroy(GO);
            }
            wayPointList.Clear();
            GameObject wayPointGO = (GameObject)Instantiate(wayPointPrefab, GetPointUnderCursor(), Quaternion.Euler(0, 0, 0));
            wayPointList.Add(wayPointGO);
        }

        //Adds waypoints without clearing the list, for Queued orders
        if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.LeftShift))
        {
            GameObject wayPointGO = (GameObject)Instantiate(wayPointPrefab, GetPointUnderCursor(), Quaternion.Euler(0, 0, 0));
            wayPointList.Add(wayPointGO);
        }

        //Starts the turn, should be bound to the starturnbutton later
        if (Input.GetMouseButtonDown(2))
        {
            startTurn = true;
        }

        //Sets the destination as the first waypoint in the waypointlist, calculates the distance between agent and next destination
        if (startTurn)
        {
            playerAgent.SetDestination(wayPointList[0].transform.position);
            wayPointDistance = Vector3.Distance(playerAgent.transform.position, wayPointList[0].transform.position);
        }

        //Switches destination to the next waypoint and removes the previous waypoint if the agent gets close, this makes sure the agent doesn't stop and start at every waypoint
        if (wayPointDistance < 1.5f && wayPointList.Count != 1)
        {
            Destroy(wayPointList[0]);
            wayPointList.RemoveAt(0);
        }
        DrawPath();
    } 

    //Draws the path between ship and nearest waypoint and all waypoints in the current path
    void DrawPath()
    {
        pathLineRenderer.positionCount = playerAgent.path.corners.Length;
        pathLineRenderer.SetPositions(playerAgent.path.corners);
        wayPointPathDrawer.GetComponent<PathDrawerScript>().DrawPath(wayPointList);  
    }

    // Creates a ray from the camera to the mouse, gets the impact point, draws a line from the object to that impact point, ignores all layers except groundplane
    private Vector3 GetPointUnderCursor()
    {
        Ray mousePosRay = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = 1 << 31;        //layer 31 is the groundlayer

        Physics.Raycast(mousePosRay, out hit, Mathf.Infinity, layerMask);  
        
        return hit.point;
    }
}
