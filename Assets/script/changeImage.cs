using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeImage : MonoBehaviour {
    public Sprite[] sprite;
    int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void change()
    {
        i++;
        if (i >= 2) {
            GetComponent<changeScene>().change("s1");
        }
        else
        GetComponent<Image>().sprite = sprite[i];
    }
}
