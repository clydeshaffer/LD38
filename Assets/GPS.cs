using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {
    float t = 0;
    public AnimationCurve ac;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        transform.localPosition = Vector3.up * ac.Evaluate(t);
	}
}
