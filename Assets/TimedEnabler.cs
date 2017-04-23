using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEnabler : MonoBehaviour {

    public float timer = 95;

    public GameObject[] enables;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer > 0) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                foreach(GameObject g in enables) {
                    g.SetActive(true);
                }
            }
        }
	}
}
