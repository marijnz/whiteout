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
        if (impendingDoom > MaxImpendingDoom) {
            GameManager.Instance.AvatarGotKilled();
            Destroy(this.gameObject);
        }

        HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point, 0.30f);
    }

    void Update() {
        
    }
}
