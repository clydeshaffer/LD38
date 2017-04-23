using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDING : MonoBehaviour {

    public Transform endGameCam;

    public AudioClip endmusic;

    void doEnding() {
        AudioSource bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        bgm.Stop();
        bgm.loop = false;
        bgm.clip = endmusic;
        bgm.pitch = 1;
        bgm.Play();
        Camera.main.GetComponent<CameraCrossFader>().mode = 1;
        Camera.main.GetComponent<CameraCrossFader>().lerpSpeed = 40;
        Camera.main.GetComponent<CameraCrossFader>().SetNewCameraTransform(endGameCam.transform);
    }

    public float activateDistance = 0.25f;

    public Transform waitForTarget;

    public Rigidbody[] disableThese;
    public GameObject warpingPrefab;

    public bool tripped = false;

    float nextLevelTimer = 6;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if(waitForTarget && !tripped) {
            if((waitForTarget.transform.position - transform.position).sqrMagnitude < (activateDistance * activateDistance)) {
                tripped = true;
                FindObjectOfType<RocketControl>().enabled = false;
                foreach(Rigidbody rb in disableThese) {
                    rb.isKinematic = true;
                }
                doEnding();

            }
        }
        if(tripped) {
            Camera.main.GetComponent<CameraCrossFader>().lerpSpeed++;
        }
    }
}
