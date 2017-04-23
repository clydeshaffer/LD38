using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDestroy : MonoBehaviour {
    public GameObject effectPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter (Collision other) {
        if(effectPrefab) {
            GameObject fx = Instantiate(effectPrefab, transform.position, Random.rotationUniform) as GameObject;
            fx.transform.LookAt(transform.position + other.contacts[0].normal);
            AudioSource aud = fx.GetComponent<AudioSource>();
            if(aud) {
                aud.pitch += (Random.value - 0.5f) * 0.2f;
            }
        }
        Destroy(gameObject);
    }
}
