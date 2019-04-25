using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject canvas;
    public GameObject winImage;
    public GameObject loseImage;
    public AudioClip win, lose;
    bool flag = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OctoGameLoop.instance.resisitanceManager.IsGameOver())
        {
            setWin(false);
        }
	}
    public void setWin(bool isWin)
    {
        if (flag)
        {
            flag = false;
            canvas.SetActive(true);
            if (isWin)
            {
                winImage.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(win);
            }
            else
            {
                foreach (var store in OctoGameLoop.instance.octoStoreManager.octoStoreSet)
                {
                    store.deathAnimation();
                }

                loseImage.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(lose);
            }
        }
    }
}
