using UnityEngine;
using System.Collections;

public class LevelShower : MonoBehaviour {

    public static LevelShower Instance;

    public Sprite Level1Sprite;
    public Sprite Level2Sprite;
    public Sprite Level3Sprite;


	// Use this for initialization
	void Awake () {
        Instance = this;
	}

    public void ShowLevel(int level) {
        switch (level) {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            //this.GetComponent<SpriteRenderer>().sprite = Level1Sprite
        }
    }
}
