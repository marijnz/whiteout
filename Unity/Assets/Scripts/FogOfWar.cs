using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour {

    public Material mat;

    GameObject fogOfWar;

	void Awake () {
        fogOfWar = GameObject.Find("r_FogOfWar");
        mat = fogOfWar.GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
     //   Debug.Log("UPDATE");
	    
	}

    /*

   public RenderTexture rt;


   [ContextMenu("Try out!")]
   void TextureTest() {
       //
       rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
       rt.Create();

       mat.SetTexture("_FogTexture", rt);
       
   }

   

   void OnRenderImage(RenderTexture source, RenderTexture dest) {
       if (mat.HasProperty("_FogTexture")) {
          // Debug.Log("JA");
           RenderTexture.active = rt;
           Texture2D texture = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
           texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
           texture.Apply();
           mat.SetTexture("_FogTexture", texture);
       }
   }

   Texture2D GetRTPixels(RenderTexture rt) {
       RenderTexture currentActiveRT = RenderTexture.active;
       RenderTexture.active = rt;
       Texture2D tex = new Texture2D(rt.width, rt.height);
       tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
       RenderTexture.active = currentActiveRT;
       return tex;
   }
   */
}
