using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour {

    public bool shouldFade = false;
	public float fadeTime = 1.5f;
	private float time;
	private float fade = 0.0f;

	Color originalColor;
	Color transparentColor;

	void Start ()
    {
		originalColor = transform.renderer.material.color;
		transparentColor = new Color (originalColor.r, originalColor.g, originalColor.b, Color.clear.a);
		setTime ();
	}

	public void setTime()
    {
		time = Time.time;
	}
	public void killFootprint ()
    {
		Destroy (this.gameObject);
	}

	void Update ()
    {
        if (!shouldFade) return;
		float elapsedTime = Time.time - time;
		if(elapsedTime > fadeTime)
			fade += Time.deltaTime;

		transform.renderer.material.color = Color.Lerp (originalColor, transparentColor, fade);

	}
}
