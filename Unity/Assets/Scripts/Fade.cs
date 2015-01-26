using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    bool hasSpriteRenderer = false;

    void Start() {
        hasSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>() != null; FadeIn();
    }

    public void FadeIn() {
        StartCoroutine(GoFadeIn());
    }

    public void FadeOut() {
        StartCoroutine(GoFadeOut());
    }

    public void FadeInOut() {
        StartCoroutine(GoFadeInOut());
    }

    IEnumerator GoFadeInOut() {
        yield return StartCoroutine(GoFadeIn());
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(GoFadeOut());
    }

    IEnumerator GoFadeIn() {
        float time = 0;
        while (time < 1.0f) {
            time += Time.deltaTime * 2.0f;
            Color c = GetColor();
            c.a = Mathf.Lerp(0, 1, time);
            SetColor(c);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator GoFadeOut() {
        float time = 0;
        while (time < 1.0f) {
            time += Time.deltaTime * 2.0f;
            Color c = GetColor();
            c.a = Mathf.Lerp(1, 0, time);
            SetColor(c);
            
            yield return new WaitForEndOfFrame();
        }
    }

    void SetColor(Color c) {
        if (hasSpriteRenderer) {
            this.GetComponent<SpriteRenderer>().color = c;
        } else {
            this.GetComponent<Renderer>().material.color = c;
        }
    }

    Color GetColor() {
        if (hasSpriteRenderer) {
            return this.GetComponent<SpriteRenderer>().color;
        } else {
            return this.GetComponent<Renderer>().material.color;
        }
    }
}
