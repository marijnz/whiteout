using UnityEngine;
using System.Collections;

public class TryAgain : MonoBehaviour {

    float timeEnabled = 0.0f;

    void OnEnable() {
        timeEnabled = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        timeEnabled += Time.deltaTime;
        if (timeEnabled > 2 && Input.anyKeyDown) {
            GameManager.Instance.StartGame();
        }
    }
}
