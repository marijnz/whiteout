using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.Play("Door Closes", transform.position);
        AudioManager.Instance.PlayDelayed("Wheezing Laugh", transform.position, 2.0f);
        GameManager.Instance.RoomGotCompleted();
        GameObject.Destroy(this.gameObject);
    }
}
