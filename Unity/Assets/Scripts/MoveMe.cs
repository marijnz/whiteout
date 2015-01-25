using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour
{
	public float moveSpeed = 0.1f;
	KeyCode moveUp = KeyCode.W;
	KeyCode moveDown = KeyCode.S;
	KeyCode moveRight = KeyCode.D;
	KeyCode moveLeft = KeyCode.A;
	private float angle;
	private bool walking;
    public int MaxHits = 50;
    public float MinTimeBetweenHits = 0.2f;
	public AvatarAnim AvatarAnimator;
    float lastHitTime;

	void Start()
	{
		walking = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
        // If the last hit was in a certain time range, ignore this hit, probably a mistake
        if (Time.time - lastHitTime < MinTimeBetweenHits) return;

        Vector2 direction = new Vector2(transform.position.x, transform.position.y) - collision.contacts[0].point;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<BloodSpatterSpawner>().Spawn(new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, -0.2f), angle);

        GetComponent<SpawnFootprints>().StartSpawning();

        lastHitTime = Time.time;
	}

	void Update ()
    {
        float moveX = CustomInputManager.GetAxis(CustomInputManager.Token.HorizontalMove, 1) * moveSpeed * Time.deltaTime;
        float moveY = CustomInputManager.GetAxis(CustomInputManager.Token.VerticalMove, 1) * moveSpeed * Time.deltaTime;
        if (moveX != 0 || moveY != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (GetComponent<Rigidbody2D>().velocity.x != 0.0f || GetComponent<Rigidbody2D>().velocity.y != 0.0f)
        {
            angle = Mathf.Atan2(moveX, -moveY) * Mathf.Rad2Deg;
        }
		GetComponent<Rigidbody2D> ().rotation = angle;

		if (!walking && moveX != 0.0f || !walking && moveY != 0.0f) {
						walking = true;
						AvatarAnimator.setWalkAnim(walking);
				}
		if (walking && moveX == 0.0f && moveY == 0.0f) {
						walking = false;
						AvatarAnimator.setWalkAnim(walking);
				}
	}
}
