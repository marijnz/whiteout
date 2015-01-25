using UnityEngine;
using System.Collections;

public class SpawnFootprints : MonoBehaviour {

	Vector3 lastfootprint;
    public float footprintOffset = 1.0f;
    public float firstFootprintOffset = 0.1f;
    public float stopSpawningAfter = 3.0f;
	public GameObject footprintPrefab;
    bool isSpawning = false;
    bool isFirstFootprint = false;
    float spawningFor = 0;

	void Start ()
    {
		lastfootprint = transform.position;
	}
	
	void Update ()
    {
        if (!isSpawning) return;

		Vector3 diff = transform.position - lastfootprint;
		float distance = diff.magnitude;
        if (distance > footprintOffset || isFirstFootprint && distance > firstFootprintOffset)
        {
            isFirstFootprint = false;
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            spawn(angle);
            spawningFor += distance;
            if (spawningFor > stopSpawningAfter)
            {
                isSpawning = false;
            }
        }
	}

    void spawn (float angle)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject tempFootprint = (GameObject)Instantiate(footprintPrefab, transform.position, rotation);
        lastfootprint = transform.position;
    }

    public void StartSpawning ()
    {
        lastfootprint = transform.position;
        isSpawning = true;
        isFirstFootprint = true;
        spawningFor = 0;
    }
}
