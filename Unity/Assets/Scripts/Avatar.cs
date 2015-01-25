using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {
	public AvatarAnim AvatarAnimator;
	bool dead;

    [SerializeField] int MaxImpendingDoom = 50;

    int impendingDoom = 0;


    public void ResetImpendingDoom() {
        impendingDoom = 0;
		dead = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        impendingDoom++;
        if (!dead && impendingDoom > MaxImpendingDoom) {
			AvatarAnimator.triggerDeathAnim();
			dead = true;
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<MoveMe>().enabled = false;
            //Destroy(this.gameObject);
        }

        HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point, 0.30f);
    }

    void Update() {
        
    }
}
