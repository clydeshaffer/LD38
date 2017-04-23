using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedReloadLevel : MonoBehaviour {

    public float fuse = 5;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        fuse -= Time.deltaTime;
        if(fuse < 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
