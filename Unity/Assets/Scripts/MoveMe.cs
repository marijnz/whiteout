using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour
{
	public float moveSpeed = 0.1f;
    public AvatarAnim AvatarAnimator;

    private Rigidbody2D Rigidbody2D;
    private float angle;
	private bool walking;

	void Start()
	{
		walking = false;
        Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update ()
    {
        if (GameManager.Instance.IsSwitchingLevel)
        {
            AvatarAnimator.setWalkAnim(false);
            Rigidbody2D.velocity = new Vector2(0, 0);
            return;
        }

        float moveX = CustomInputManager.GetAxis(CustomInputManager.Token.HorizontalMove, 1) * moveSpeed * Time.deltaTime;
        float moveY = CustomInputManager.GetAxis(CustomInputManager.Token.VerticalMove, 1) * moveSpeed * Time.deltaTime;
        Rigidbody2D.velocity = new Vector2(moveX, moveY);
        if (Rigidbody2D.velocity.x != 0.0f || Rigidbody2D.velocity.y != 0.0f)
        {
            angle = Mathf.Atan2(moveX, -moveY) * Mathf.Rad2Deg;
        }

        Rigidbody2D.rotation = angle;

		if (!walking && moveX != 0.0f || !walking && moveY != 0.0f)
        {
            walking = true;
            AvatarAnimator.setWalkAnim(walking);
		}

		if (walking && moveX == 0.0f && moveY == 0.0f)
        {
            walking = false;
            AvatarAnimator.setWalkAnim(walking);
        }
	}
}
