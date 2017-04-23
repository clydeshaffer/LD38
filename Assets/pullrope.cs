using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullrope : MonoBehaviour {

    LineRenderer lr;
    Joint sj;
    public float rope_extension = 1;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        sj = GetComponent<Joint>();
	}
	
	// Update is called once per frame
	void Update () {
        if(rope_extension < 1) {
            rope_extension += Time.deltaTime / 3;
        }
        if(sj.connectedBody) {
            Vector3 ropeOrigin = transform.position + Vector3.up * 0.04f - transform.forward * 0.06f;
            lr.SetPosition(0, ropeOrigin);
            lr.SetPosition(1, Vector3.Lerp(ropeOrigin, sj.connectedBody.transform.position, rope_extension));
        } else {
            lr.enabled = false;
        }
	}
}
