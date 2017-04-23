using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceMusic : MonoBehaviour {



	// Use this for initialization
	void Start () {
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
