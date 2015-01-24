using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {


    [SerializeField] int MaxHits = 50;

    private int impendingDoom = 0;

    void OnCollisionEnter2D(Collision2D collision) {
        impendingDoom++;
        HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point);
    }

    void Update() {
        if (impendingDoom > MaxHits) {
            StartCoroutine(StartDying());
        }
    }

    IEnumerator StartDying() {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.AvatarGotKilled();
        Destroy(this.gameObject);
    }

}
