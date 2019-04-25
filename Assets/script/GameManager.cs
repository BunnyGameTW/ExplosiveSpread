using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] prefabs;
    public Transform[] targets;
    public int person;
	// Use this for initialization
	void Start () {
      for(int i = 1; i < person; i++)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], targets[Random.Range(0, targets.Length)].position, new Quaternion());
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }

}
