using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {
    public GameObject hoverObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseOver()
    {
        hoverObject.SetActive(true);
    }
    public void OnMouseExit()
    {
        hoverObject.SetActive(false);
    }
}
