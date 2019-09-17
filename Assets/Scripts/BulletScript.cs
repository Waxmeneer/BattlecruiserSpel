using UnityEngine;

public class BulletScript : MonoBehaviour {

    private Vector3 target;
    private Vector3 startPoint;
    public float speed = 10f;
    private float range = 50f;
    public float damage = 10;
    private float distanceTravelled = 0f;
    private bool maxRangeEnabled = true;

    public void SetTargetLocation(Vector3 targetLoc, Vector3 firePoint)
    {
        target = targetLoc;
        startPoint = firePoint;
    }

	// Calculates a direction, then travels in that direction until target is reached. Optionally a maxrange can be added
	void Update () {
        Vector3 direction = target - startPoint;
        float distanceThisFrame = speed * Time.deltaTime;
        distanceTravelled += distanceThisFrame;

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

        if (distanceTravelled >= range && maxRangeEnabled)
        {
            Destroy(gameObject);
        }
	}

    //On collision, destroys bullet, however, this method of collision detection does not work on high speed bullets, try raycastmethod!
    void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        health.GetDamaged(damage);
        Destroy(gameObject);
    }
}
