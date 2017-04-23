using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    bool didStart = false;
    float startCountdown = 6;

    public MonoBehaviour[] enableTheseAtLevelStart;

	// Use this for initialization
	void Start () {
        orbit.orbits_enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(!didStart && Input.GetKeyDown("return")) {
            didStart = true;
            FindObjectOfType<RocketAnimator>().go = true;
            GetComponent<AudioSource>().Play();
        }

        if(didStart && startCountdown > 0) {
            startCountdown -= Time.deltaTime;
            if(startCountdown <= 0) {
                GetComponent<Rigidbody>().velocity = Vector3.forward * -0.05f;
                orbit.orbits_enabled = true;
                foreach(MonoBehaviour g in enableTheseAtLevelStart) {
                    g.enabled = true;
                }
                Camera.main.GetComponent<CameraCrossFader>().SetNewCameraTransform(GameObject.Find("GameCam1").transform);
            }
        }
	}
}
