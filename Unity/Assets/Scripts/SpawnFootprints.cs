using UnityEngine;
using System.Collections;

public class SpawnFootprints : MonoBehaviour {

	Vector3 lastfootprint;
	public float footprintOffset = 1.0f;
	public GameObject footprintPrefab;
	// Use this for initialization
	void Start () {
		lastfootprint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = transform.position - lastfootprint;
		float distance = diff.magnitude;
		if (distance > footprintOffset) {
			float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			GameObject tempFootprint  = (GameObject) Instantiate (footprintPrefab, transform.position, rotation);
			lastfootprint = transform.position;
		}
	}
}
