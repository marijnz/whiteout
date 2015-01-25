using UnityEngine;
using System.Collections;

public class HitpointManager : MonoBehaviour {

    public static HitpointManager Instance;

    [SerializeField]
    Hitpoint HitpointPrefab;

    public Vector2 SpawnAt;

	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    [ContextMenu("Spawn")]
    void OnMouseDown() {
        SpawnHitPoint(SpawnAt);
    }

    public void SpawnHitPoint(Vector2 position, float maxDistance = 300 ) {
        Hitpoint hitpoint = Instantiate(HitpointPrefab) as Hitpoint;
        hitpoint.transform.position = position;
        hitpoint.Spawn(maxDistance);
    }
}
