using UnityEngine;
using System.Collections;

public class Hitpoint : MonoBehaviour {

    readonly float maxDistance = 300;

    float elapsedTime = 0;
    float growingTime = 1f;

    bool isSpawning = false;
    bool hasRendered = false;

	void Update () {
        if (hasRendered) {
            DestroyImmediate(this.gameObject);
        }
        if (!isSpawning) { return; }
        Texture2D texture = new Texture2D(610, 610);

        renderer.material.mainTexture = texture;

        elapsedTime += Time.deltaTime;
        elapsedTime = growingTime;
        Vector2 center = new Vector2(texture.width / 2, texture.height / 2);

        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                float amountOfGreen = ((maxDistance * (elapsedTime / growingTime)) - Vector2.Distance(center, new Vector2(x, y))) / maxDistance;
                amountOfGreen = amountOfGreen < 0 ? 0 : amountOfGreen;
                texture.SetPixel(x, y, new Color(0, 1, 0, amountOfGreen));
            }
        }

        texture.Apply();

        if (elapsedTime >= growingTime) {
            isSpawning = false;
           
        }
        hasRendered = true;
	}

    void OnPostRender() {

    }

    public void Spawn() {

        isSpawning = true;


       
    }
}
