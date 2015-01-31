using UnityEngine;
using System.Collections;

public class LevelShower : MonoBehaviour {

    public static LevelShower Instance;

    public Sprite Level1Sprite;
    public Sprite Level2Sprite;
    public Sprite Level3Sprite;
    public Sprite Level4Sprite;


	// Use this for initialization
	void Awake () {
        Instance = this;
	}

    public void ShowLevel(int level) {
        switch (level) {
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = Level1Sprite;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = Level2Sprite;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = Level3Sprite;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = Level4Sprite;
                break;
            //this.GetComponent<SpriteRenderer>().sprite = Level1Sprite
        }
        this.GetComponent<Fade>().FadeInOut();
    }
}
