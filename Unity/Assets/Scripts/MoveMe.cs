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
    public int MaxHits = 50;

	void OnCollisionEnter2D(Collision2D collision)
    {
        HitpointManager.Instance.SpawnHitPoint(collision.contacts[0].point);

        Vector2 direction = new Vector2(transform.position.x, transform.position.y) - collision.contacts[0].point;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<BloodSpatterSpawner>().Spawn(new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, -0.2f), angle);

        GetComponent<SpawnFootprints>().StartSpawning();
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
		if(CustomInputManager.ButtonGotPressed(CustomInputManager.Token.Interact, 1)){
			print ("What do we do now?");
		}
		
	}
}
