using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleButton : MonoBehaviour {
    Text text;
    float speed = 1;
	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onTimeScaleButtonClick()
    {
        if(speed == 1.0f)
        {
            speed = 1.5f;
        }
        else if (speed == 1.5f)
        {
            speed = 2.0f;
        }
        else if (speed == 2.0f)
        {
            speed = 1.0f;
        }
        text.text = "X" + speed.ToString();
    }
}
