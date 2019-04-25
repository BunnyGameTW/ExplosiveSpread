using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

    public GameObject bgmPrefab;
    GameObject bgmInstance = null;
    // Use this for initialization
    void Start()
    {
        bgmInstance = GameObject.FindGameObjectWithTag("music");
        if (bgmInstance == null)
        {
            bgmInstance = (GameObject)Instantiate(bgmPrefab);
        }

    }
}
