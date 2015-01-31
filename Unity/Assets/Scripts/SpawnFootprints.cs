using UnityEngine;
using System.Collections;

public class SpawnFootprints : MonoBehaviour {

    public static SpawnFootprints Instance;

	Vector3 lastfootprint;
    public float footprintOffset = 1.0f;
    public float firstFootprintOffset = 0.1f;
    public float stopSpawningAfter = 3.0f;
	public GameObject footprintPrefab;
    public bool isSpawning = false;
    bool isFirstFootprint = false;
    float spawningFor = 0;
    public GameObject holder;

    void Awake ()
    {
        Instance = this;
        holder = GameObject.Find("BloodHolder");
    }

	void Start ()
    {
		lastfootprint = transform.position;
	}
	
	void Update ()
    {
        if (!isSpawning) return;

		Vector3 diff = transform.position - lastfootprint;
        diff.z = 0;
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
        GameObject tempFootprint = (GameObject)Instantiate(footprintPrefab, transform.position + new Vector3(0, 0, 0.01f), rotation);
        lastfootprint = transform.position;
        tempFootprint.transform.parent = holder.transform;

        Color c = tempFootprint.renderer.material.color;
        c.a = 1 - spawningFor / stopSpawningAfter - 0.3f;
        tempFootprint.renderer.material.color = c;
    }

    public void StartSpawning ()
    {
        lastfootprint = transform.position;
        isSpawning = true;
        isFirstFootprint = true;
        spawningFor = 0;
    }

    public void ClearBlood ()
    {
        foreach (Transform child in holder.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
