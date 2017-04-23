using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCrossFader : MonoBehaviour {

    public Transform trackTarget;
    Transform previousTarget;

    public int mode = 0;

    public float lerpSpeed = 0.5f;

    float lerpscale = 1;

    public void SetNewCameraTransform(Transform t) {
        lerpscale = 0;
        previousTarget = trackTarget;
        trackTarget = t;
    }

	// Use this for initialization
	void Start () {
        previousTarget = trackTarget;
	}
	
	// Update is called once per frame
	void OnPreRender () {
        if (lerpscale < 1)
            lerpscale += Time.deltaTime * lerpSpeed;
        
        if(mode == 0) {
            transform.position = Vector3.Lerp(previousTarget.transform.position, trackTarget.transform.position, lerpscale);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, trackTarget.transform.position, lerpSpeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.Slerp(previousTarget.transform.rotation, trackTarget.transform.rotation, lerpscale);
	}
}
