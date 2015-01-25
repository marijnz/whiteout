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
	public void triggerDeathAnim() {
		AvatarAnimator.SetTrigger ("Death");
		Debug.Log ("Death anim triggered");
	}
	public void OnDeathAnimationFinished()
	{
		GameManager.Instance.AvatarGotKilled();
		Destroy (transform.parent.gameObject);
        Debug.Log("DIE!");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
