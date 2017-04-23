using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour {

    public static bool orbits_enabled = false;

    public float t_offset = 0;
    public float t_scale = 1;

    public bool auto_init = false;

    public Vector2 orbit_scale = Vector2.one;

    public float rotateSpeed = 0;

    public float t = 0;

	// Use this for initialization
	void Start () {
        if(auto_init) {
            orbit_scale = Vector2.one * transform.position.magnitude;
            t_offset = Mathf.Atan2(transform.position.z, transform.position.x);
            rotateSpeed = Random.Range(5, 15);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(orbits_enabled) {
            t += Time.deltaTime;
        }
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        transform.position = Mathf.Cos((t * t_scale * 0.1f) + t_offset) * orbit_scale.x * Vector3.right
            + Mathf.Sin((t * t_scale * 0.1f) + t_offset) * orbit_scale.y * Vector3.forward;
	}
}
