using UnityEngine;
using System.Collections;

public class TryAgain : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown) {
            Application.LoadLevel("Main");
        }
    }
}
