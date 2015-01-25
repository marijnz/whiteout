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
                this.GetComponent<SpriteRenderer>().sprite = Level1Sprite;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = Level2Sprite;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = Level3Sprite;
                break;
            //this.GetComponent<SpriteRenderer>().sprite = Level1Sprite
        }
        Debug.Log("SHOWING LEVEL");
        StartCoroutine(GoShowLevel());
    }

    IEnumerator GoShowLevel() {
        float time = 0;
        while (time < 1.0f) {
            time += Time.deltaTime * 2.0f;
            Color c = this.GetComponent<SpriteRenderer>().color;
            c.a = Mathf.Lerp(0, 1, time);
            this.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.0f);
        time = 0;
        while (time < 1.0f) {
            time += Time.deltaTime * 2.0f;
            Color c = this.GetComponent<SpriteRenderer>().color;
            c.a = Mathf.Lerp(1,0, time);
            this.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForEndOfFrame();
        }
    }
}
