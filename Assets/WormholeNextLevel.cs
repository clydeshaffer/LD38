using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormholeNextLevel : MonoBehaviour {

    public float activateDistance = 0.25f;

    public Transform waitForTarget;

    public GameObject[] disableThese;
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
                foreach(GameObject g in disableThese) {
                    Instantiate(warpingPrefab, g.transform.position, transform.rotation);
                    g.SetActive(false);
                }
            }
        }
        if(tripped) {
            if(nextLevelTimer > 0) {
                nextLevelTimer -= Time.deltaTime;
                if(nextLevelTimer <= 0) {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
	}
}
