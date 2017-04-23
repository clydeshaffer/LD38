using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour {

    public float fuse = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fuse -= Time.deltaTime;
        if(fuse < 0) {
            Destroy(gameObject);
        }
	}
}
