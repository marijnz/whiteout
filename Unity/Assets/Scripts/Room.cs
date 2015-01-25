using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	[SerializeField] Transform SpawnPositionTransform;

    public Vector3 SpawnLocation {
        get {
            return SpawnPositionTransform.transform.position;
        }
    }


}
