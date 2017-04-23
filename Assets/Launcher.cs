using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public GameObject prefab;

    public float spawnDist = 10;

    public Transform aimtarget;
    public float aimChance = 0.5f;

    public float interval = 3;
    public float intervalVariance = 1;

    public float spawnSpacing = 1;

    public float arc = Mathf.PI * 2;
    public float arc_offset = 0;

    public int count = 1;
    public int countVariance = 4;

    float timer = 5;

	// Use this for initialization
	void Start () {
		
	}
	
    Vector3 pointOnCircle(float theta, float radius) {
        return (Mathf.Sin(theta) * Vector3.forward + Mathf.Cos(theta) * Vector3.right) * radius;
    }

	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0) {
            timer += interval + Random.value * intervalVariance;
            int spawnCount = count + Random.Range(0, countVariance);
            float theta = Random.value * arc + arc_offset;
            Vector3 spawnCenter = transform.position + pointOnCircle(theta, spawnDist);
            Vector3 aimPoint = transform.position;
            if(aimtarget) {
                if(Random.value < aimChance) {
                    aimPoint = aimtarget.position;
                }
            }
            for(int i = 0; i < spawnCount; i++) {
                GameObject newAster = Instantiate(prefab, spawnCenter + pointOnCircle(2 * i * Mathf.PI / spawnCount, spawnSpacing), Random.rotationUniform) as GameObject;
                Rigidbody newRB = newAster.GetComponent<Rigidbody>();
                newRB.angularVelocity = Random.onUnitSphere * 0.25f;
                newRB.velocity = (aimPoint - spawnCenter).normalized + Random.onUnitSphere * 0.1f;
                newRB.velocity = Vector3.Scale(newRB.velocity, Vector3.forward + Vector3.right);
            }
        }
	}
}
