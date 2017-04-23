using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeIn : MonoBehaviour {

    float existingVolume = 0;
    float t = -1;
    AudioSource aus;
	// Use this for initialization
	void Start () {
        aus = GetComponent<AudioSource>();
        existingVolume = aus.volume;
        aus.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(t < 3) {
            t += Time.deltaTime;
            if(t > 0)
                aus.volume = (t / 3) * existingVolume;
        }
	}
}
