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
	public AvatarAnim AvatarAnimator;

	void Start()
	{
		walking = false;
	}

	void Update ()
    {
        if (GameManager.Instance.IsSwitchingLevel) {
            AvatarAnimator.setWalkAnim(false);
            return;
        }
        float moveX = CustomInputManager.GetAxis(CustomInputManager.Token.HorizontalMove, 1) * moveSpeed * Time.deltaTime;
        float moveY = CustomInputManager.GetAxis(CustomInputManager.Token.VerticalMove, 1) * moveSpeed * Time.deltaTime;
     //  if (moveX != 0 || moveY != 0)
     //  {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
       // }
       // else
       // {
       //     GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       // }
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
