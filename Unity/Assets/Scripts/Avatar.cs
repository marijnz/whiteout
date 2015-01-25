using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {


    [SerializeField] int MaxImpendingDoom = 50;

    int impendingDoom = 0;

    float MinTimeBetweenHits = 0.5f;

    float lastHitTime;



    public void ResetImpendingDoom() {
        impendingDoom = 0;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        // If the last hit was in a certain time range, ignore this hit, probably a mistake
        if ((Time.time - lastHitTime) <= MinTimeBetweenHits) return;
        Vector2 direction = new Vector2(transform.position.x, transform.position.y) - collision.contacts[0].point;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<BloodSpatterSpawner>().Spawn(new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, -0.2f), angle);

        GetComponent<SpawnFootprints>().StartSpawning();

        lastHitTime = Time.time;

        impendingDoom++;
        AudioManager.Instance.Play("Fainting", transform.position);

        if (impendingDoom > MaxImpendingDoom) {
            //AudioManager.Instance.Play("Fainting", transform.position);

            GameManager.Instance.AvatarGotKilled();
            Destroy(this.gameObject);
        }

        HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point, 0.30f);
    }

    void Update() {
        
    }
}
