using UnityEngine;
using System.Collections;

public class Hitpoint : MonoBehaviour {

    readonly float maxDistance = 100;

    float elapsedTime = 0;
    float growingTime = 1f;

    bool isSpawning = false;

	void Update () {

        if (!isSpawning) { return; }
        Texture2D texture = new Texture2D(512, 512);

        renderer.material.mainTexture = texture;

        elapsedTime += Time.deltaTime;

        Vector2 center = new Vector2(texture.width / 2, texture.height / 2);

        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                //Debug.Log(Vector2.Distance(center, currentPos));

                float amountOfGreen = ((maxDistance * (elapsedTime / growingTime)) - Vector2.Distance(center, new Vector2(x, y))) / maxDistance;
                amountOfGreen = amountOfGreen < 0 ? 0 : amountOfGreen;
                    //Color toColor = Color.green * AmountOfGreen * ElaspedTime / 100 / maxDistance;
                    //Color toColor = Color.green * amountOfGreen;
                    ///  Debug.Log(toColor.g);
                    //texture.SetPixel(x, y, toColor);
                    texture.SetPixel(x, y, new Color(0, 1, 0, amountOfGreen));
                // Debug.Log(val);
            }
        }

        texture.Apply();

        if (elapsedTime > growingTime) {
            isSpawning = false;
        }
	}

    public void Spawn() {

        isSpawning = true;

       
    }
}
