using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.LevelGotCompleted();
    }
}
