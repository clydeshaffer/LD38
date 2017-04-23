using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour {

    public float force = 5;

    ParticleSystem ps;
    AudioSource aus;

	// Use this for initialization
	void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
        aus = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 inputForward = transform.root.forward;
        Vector3 inputRight = transform.root.right;
        Vector3 inputDir = Input.GetAxis("Vertical") * inputForward + Input.GetAxis("Horizontal") * inputRight;
        GetComponent<Rigidbody>().AddForce(inputDir * force);
        float inputmag = inputDir.sqrMagnitude;
        if(inputmag > 0) {
            transform.LookAt(transform.position + inputDir);
            aus.volume = 0.1f * inputmag;
            if(!ps.isPlaying) {
                ps.Play();
            }
        } else {
            ps.Stop();
            aus.volume = 0;
        }

	}
}
