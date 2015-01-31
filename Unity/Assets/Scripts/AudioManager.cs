using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class AudioContainer {
    public string Name;
    public AudioClip AudioClip;
    [Range(0, 1)]
    public float Volume;
    public bool Looping = false;
}


public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    [SerializeField]
    List<AudioContainer> AudioContainers;

    Dictionary<string, AudioContainer> AudioContainerDict = new Dictionary<string, AudioContainer>();

    void Awake() {
        Instance = this;
        foreach (AudioContainer audioContainer in AudioContainers) {
            AudioContainerDict.Add(audioContainer.Name, audioContainer);
        }
    }

    public void Play(string name, Vector3 position)
    {
        AudioContainer audioContainer = AudioContainerDict[name];
        if (audioContainer.Looping)
        {
            GameObject go = new GameObject();
            DontDestroyOnLoad(go);
            go.transform.position = position;
            go.AddComponent<AudioSource>();
            go.audio.loop = true;
            go.audio.volume = audioContainer.Volume;
            go.audio.clip = audioContainer.AudioClip;
            go.audio.Play();
        }
        else
        {
            AudioSource.PlayClipAtPoint(audioContainer.AudioClip, position, audioContainer.Volume);
        }
    }

    public void PlayDelayed (string name, Vector3 position, float delay)
    {
        StartCoroutine(Delayed(name, position, delay));
    }

    IEnumerator Delayed(string name, Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);

        Play(name, position);
    }
}
