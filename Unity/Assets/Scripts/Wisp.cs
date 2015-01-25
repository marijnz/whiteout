using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour
{
    WispWaypoint nextWispWaypoint;
    public Animation anim;

    public void Start ()
    {
        anim["Wisp"].time = Random.value * anim["Wisp"].length;
    }

    public void MoveTo(WispWaypoint pos)
    {
        nextWispWaypoint = pos;
    }

	void Update ()
    {
        float step = 1.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextWispWaypoint.getPosition(), step);

        Vector2 direction = nextWispWaypoint.getPosition() - transform.position;
        float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        if (Vector2.Distance(this.transform.position, nextWispWaypoint.getPosition()) < 0.1f)
        {
            MoveTo(nextWispWaypoint.getNextWaypoint());
        }
	}

    public void JumpToRandomPositionOnLine ()
    {
        float distanceToGo = Vector2.Distance(this.transform.position, nextWispWaypoint.getPosition());
        transform.position = Vector3.MoveTowards(transform.position, nextWispWaypoint.getPosition(), Random.value * distanceToGo);
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
