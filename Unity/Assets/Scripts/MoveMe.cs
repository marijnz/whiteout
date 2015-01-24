using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour {

	public float moveSpeed = 0.1f;
	KeyCode moveUp = KeyCode.W;
	KeyCode moveDown = KeyCode.S;
	KeyCode moveRight = KeyCode.D;
	KeyCode moveLeft = KeyCode.A;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = CustomInputManager.GetAxis (CustomInputManager.Token.HorizontalMove, 1);
		float moveY = CustomInputManager.GetAxis (CustomInputManager.Token.VerticalMove, 1);
		transform.Translate (moveX, moveY, 0);

		if(CustomInputManager.ButtonGotPressed(CustomInputManager.Token.Interact, 1)){
			print ("What do we do now?");
		}
	}
}
