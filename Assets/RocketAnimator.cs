using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimator : MonoBehaviour {

    public AnimationCurve backup_anim;
    public Transform targetTransform;

    public bool go = false;

    public float anim_t = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(go) {
            if(anim_t < 3) {
                anim_t += Time.deltaTime;
                targetTransform.localPosition = Vector3.forward * backup_anim.Evaluate(anim_t);
                if(anim_t >= 3) {
                    GetComponent<pullrope>().enabled = true;
                    GetComponent<LineRenderer>().enabled = true;
                }
            }
        }
	}
}
