using UnityEngine;
using System.Collections;

public class AvatarAnim : MonoBehaviour {
	public Animator AvatarAnimator;

	// Use this for initialization
	void Start () {
	
	}

	public void setWalkAnim(bool anim){
		AvatarAnimator.SetBool ("Walk", anim);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
