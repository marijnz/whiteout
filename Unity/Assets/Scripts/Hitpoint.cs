﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hitpoint : MonoBehaviour {

    float elapsedTime = 0;
    float growingTime = 1f;

    bool isSpawning = false;
    bool hasRendered = false;

	void Update () {
        if (hasRendered) {
            DestroyImmediate(this.gameObject);
            return;
        }

        if (!isSpawning) { return; }

        float MaxDistance = 10;
        Texture2D texture = new Texture2D((int) MaxDistance * 2 + 2, (int) MaxDistance * 2 + 2);
        
        elapsedTime += Time.deltaTime * 5;

        Vector2 center = new Vector2(texture.width / 2, texture.height / 2);

      //  List<Color> colors = new List<Color>();

        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                float amountOfGreen = ((MaxDistance * (elapsedTime / growingTime)) - Vector2.Distance(center, new Vector2(x, y))) / MaxDistance;
                amountOfGreen = amountOfGreen < 0 ? 0 : amountOfGreen;
                texture.SetPixel(x, y, new Color(0, 1, 0, amountOfGreen));
            }
        }
        renderer.material.mainTexture = texture;
      //  texture.SetPixels32


        texture.Apply();

        if (elapsedTime >= growingTime) {
            isSpawning = false;
            hasRendered = true;
           
        }
	}

    void OnPostRender() {

    }

    public void Spawn(float scale) {
        this.transform.localScale = Vector3.one * scale;
        isSpawning = true;
    }
}
