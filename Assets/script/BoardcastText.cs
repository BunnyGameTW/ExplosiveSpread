using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoardcastText : MonoBehaviour {
    public string[] boardcastText;
    public GameObject textObject;
	// Use this for initialization
	void Start () {
		for(int i = 1; i < 3; i++)
        {
            spawnBoardcastText(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnBoardcastText(int i)//TODO 幹畫跟事件文字大小要分開
    {
        Vector2 vec = new Vector2();
        vec.y = Random.Range(-530, 530);
        GameObject gameObejct = Instantiate(textObject, new Vector3(), new Quaternion(), this.transform);
        gameObejct.GetComponentInChildren<Text>().text = boardcastText[i];
        gameObejct.GetComponentInChildren<Text>().fontSize = 35;//TODO
        gameObejct.GetComponent<RectTransform>().anchoredPosition = vec;
    }
}
