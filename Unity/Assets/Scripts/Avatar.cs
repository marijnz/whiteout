using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {
	public AvatarAnim AvatarAnimator;
	bool dead;

    [SerializeField] int MaxImpendingDoom = 50;

    int impendingDoom = 0;

    float MinTimeBetweenHits = 0.5f;

    float lastHitTime;

    public void ResetImpendingDoom() {
        impendingDoom = 0;
		dead = false;
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
            if (!dead)
            {
                AvatarAnimator.triggerDeathAnim();
                dead = true;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<MoveMe>().enabled = false;
            }
            HitpointManager.Instance.SpawnHitPoint(transform.position, 0.45f, true);
        } else {
            HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point, 0.40f);
        }
    }
}
