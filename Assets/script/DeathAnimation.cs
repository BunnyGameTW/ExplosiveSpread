using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour {
   // public GameObject effect;

	// Use this for initialization
	void Start () {
        playDeathAnimation();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playDeathAnimation()
    {
      //  Instantiate(effect, transform);
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, Random.Range(2, 3) * 10), ForceMode.Impulse);
        rb.angularVelocity = new Vector3(100, 100, 100);
    }
}
