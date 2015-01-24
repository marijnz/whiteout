using UnityEngine;
using System.Collections;

public class FOWRenderTextureCamera : MonoBehaviour {

    public static FOWRenderTextureCamera Instance;

    void Awake() {
        Instance = this;
        ResetFogOfWar();
    }

    public void ResetFogOfWar() {
        this.GetComponent<Camera>().targetTexture.DiscardContents(true, true);
        this.GetComponent<Camera>().targetTexture.Release();
    }
}
