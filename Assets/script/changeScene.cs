using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void change(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    public void exit()
    {
        Application.Quit();
    }
}
