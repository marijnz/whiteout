using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {


    [SerializeField] int MaxImpendingDoom = 50;

    int impendingDoom = 0;


    public void ResetImpendingDoom() {
        impendingDoom = 0;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        impendingDoom++;
        HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point, 200);
    }

    void Update() {
        if (impendingDoom > MaxImpendingDoom) {
            StartCoroutine(StartDying());
        }
    }

    IEnumerator StartDying() {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.AvatarGotKilled();
        Destroy(this.gameObject);
    }

}
