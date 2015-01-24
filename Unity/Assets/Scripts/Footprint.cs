using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour {

	public float fadeTime = 1.5f;
	private float time;
	private float fade = 0.0f;

	Color originalColor;
	Color transparentColor;

	// Use this for initialization
	void Start () {
		originalColor = transform.renderer.material.color;
		transparentColor = new Color (originalColor.r, originalColor.g, originalColor.b, Color.clear.a);
		setTime ();
	}
	public void setTime()	{
		time = Time.time;
	}
	public void killFootprint (){
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () {
		float elapsedTime = Time.time - time;
		if(elapsedTime > fadeTime)
			fade += elapsedTime;

		transform.renderer.material.color = Color.Lerp (originalColor, transparentColor, fade);

	}
}
