using UnityEngine;
using System.Collections;

public class HitpointManager : MonoBehaviour {

    [SerializeField]
    Hitpoint HitpointPrefab;

    public Vector2 SpawnAt;

	// Use this for initialization
	void Start () {
       // SpawnHitPoint(new Vector2(1, 1));
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    [ContextMenu("Spawn")]
    void OnMouseDown() {
        SpawnHitPoint(SpawnAt);
    }

    public void SpawnHitPoint(Vector2 position) {
        Hitpoint hitpoint = Instantiate(HitpointPrefab) as Hitpoint;
        hitpoint.transform.position = position;
        hitpoint.Spawn();
    }
}
