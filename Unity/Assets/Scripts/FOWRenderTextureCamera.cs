using UnityEngine;
using System.Collections;

public class FOWRenderTextureCamera : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        this.GetComponent<Camera>().targetTexture.DiscardContents(true, true);
        this.GetComponent<Camera>().targetTexture.Release();
        //this.GetComponent<Camera>().targetTexture.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
