using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public float scrollSpeed = 2f;
    public float panBorderThickness = 10f;

	// Update is called once per frame
	void Update () {

        Vector3 camPos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            camPos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            camPos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            camPos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <=  panBorderThickness)
        {
            camPos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camPos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        transform.position = camPos;
        
	}
}
