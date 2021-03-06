﻿using UnityEngine;
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
        SpawnHitPoint(SpawnAt, 300);
    }

    public void SpawnHitPoint(Vector2 position, float maxDistance, bool respawnOnLevelReset = false) {
        StartCoroutine(GoSpawnHitPoint(position, maxDistance, respawnOnLevelReset));
    }

    IEnumerator GoSpawnHitPoint(Vector2 position, float maxDistance, bool respawnOnLevelReset) {
        yield return new WaitForEndOfFrame();
        Hitpoint hitpoint = Instantiate(HitpointPrefab) as Hitpoint;
        hitpoint.transform.position = position;
        hitpoint.Spawn(maxDistance, respawnOnLevelReset);
    }
}
