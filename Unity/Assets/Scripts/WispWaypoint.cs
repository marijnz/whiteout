using UnityEngine;
using System.Collections;

public class WispWaypoint : MonoBehaviour {

    public WispWaypoint[] connectedWaypoints;

    public Vector3 getPosition ()
    {
        return transform.position;
    }

    public WispWaypoint getNextWaypoint ()
    {
        return connectedWaypoints[Mathf.FloorToInt(Random.value * connectedWaypoints.Length)];
    }
}
