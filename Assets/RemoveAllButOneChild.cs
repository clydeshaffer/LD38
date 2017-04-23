using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAllButOneChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int childCount = transform.childCount;
        int keeper = Random.Range(0, childCount);
        for(int i = childCount - 1; i >= 0; i --) {
            if(i != keeper) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
