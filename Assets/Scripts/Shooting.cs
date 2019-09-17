using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Vector3 finalHitPoint = new Vector3();  //Added a finalHitPoint so that I can later more easily edit the actual hit.point

    private LineRenderer LR;
    private Camera mainCam;

    // Assigns the LineRenderer and mainCam objects to be used later
    void Start () {
        LR = GetComponent<LineRenderer>();                  
        mainCam = Camera.main;
	}
	
	// Handles firing and the predictive line rendered to show where the bullets go
	void Update () {

        // Creates a ray from the camera to the mouse, gets the impact point, draws a line from the object to that impact point
        Ray mousePosRay = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = 1 << 31;

        if (Physics.Raycast(mousePosRay, out hit, Mathf.Infinity, layerMask))
        {
            finalHitPoint = hit.point;
            finalHitPoint.y = transform.localPosition.y;
        }
        LR.SetPosition(0, transform.localPosition);
        LR.SetPosition(1, finalHitPoint);

        //Calls the firing script on leftclick
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
	}

    //Spawns the bullet and assigns the bulletscript to set a targetlocation
    void Fire()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();

        if (bullet != null)
        {
            bullet.SetTargetLocation(finalHitPoint, firePoint.position);
        }
    }
}
