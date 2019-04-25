using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MonryText : MonoBehaviour {

    int showMoney;
    Text moneyText;
	void Start () {
        showMoney = (int)OctoGameLoop.instance.skillPointManager.GetTotalMoney();
        moneyText = GetComponentInChildren<Text>();
	}
	
	
	void Update () {
        UpdateShowMoney();
    }

    void UpdateShowMoney()
    {
        if ((int)OctoGameLoop.instance.skillPointManager.GetTotalMoney() > showMoney)
        {
            if ((int)OctoGameLoop.instance.skillPointManager.GetTotalMoney() - showMoney > 10)
                showMoney += 10;
            else
                showMoney++;
        }
        else if ((int)OctoGameLoop.instance.skillPointManager.GetTotalMoney() < showMoney)
            showMoney = (int)OctoGameLoop.instance.skillPointManager.GetTotalMoney();

        moneyText.text = Convert.ToString(showMoney);
   }
}
