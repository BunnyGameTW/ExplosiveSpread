using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoardcastText : MonoBehaviour {
    public string[] boardcastText;
    public GameObject textObject;
    float timer = 0, boardCastTime = 0;
	// Use this for initialization
	void Start () {
        randomTime();

		//for(int i = 1; i < 3; i++)
  //      {
  //          spawnBoardcastText(i);
  //      }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > boardCastTime)
        {
            timer = 0;
            randomTime();
            spawnBoardcastText();
        }

    }
    void randomTime()
    {
        boardCastTime = Random.Range(0.5f, 3.0f);
    }
    public void spawnBoardcastText()
    {
        spawnText(boardcastText[Random.Range(0,boardcastText.Length)], 35, 0);
    }

    public void spawnEventText(string str)
    {
        spawnText(str, 59, 1);
    }
    void spawnText(string str, int fontSize, int type)
    {
        Vector2 vec = new Vector2();
        vec.y = Random.Range(-500, 500);
        GameObject gameObejct = Instantiate(textObject, new Vector3(), new Quaternion(), this.transform);
        gameObejct.GetComponentInChildren<Text>().text = str;
        gameObejct.GetComponentInChildren<Text>().fontSize = fontSize;
        gameObejct.GetComponent<RectTransform>().anchoredPosition = vec;
        gameObejct.GetComponentInChildren<TextMove>().setAnimationType(type);
    }
}
