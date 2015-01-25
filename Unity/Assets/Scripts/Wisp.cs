using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour {

    Vector2 moveTo;

    public void MoveTo(Vector2 pos) {
        moveTo = pos;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float step = 2.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTo, step);

        if (Vector2.Distance(this.transform.position, moveTo) < 0.1f) {
            WispManager.Instance.AskForNewDirection(this);
        }
	}

    public void Kill() {
        Destroy(this.gameObject);
    }
}
