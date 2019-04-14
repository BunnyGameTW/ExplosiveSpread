using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class SkillButtonEventArgs : EventArgs
{
    public string skillName;
    public int skillPoint = 0;
}
public class PlayerSkill : MonoBehaviour {
    float LEVEL_VALUE = 10.0f;//升等的加權值
    
    int totalMoney = 0;
    int usedSkillPoint = 0;
    int[] skillPointArray;
    int[] moneyMap;
    float[] skillValueArray;//點下去後座值的計算

    int skillIndex = 0;

    public Text skillPointText;
    public GameObject skills;
    public event EventHandler<SkillButtonEventArgs> skillButtonClicked;

    // Use this for initialization
    void Start () {
        moneyMap = new int[] { 10, 100, 500, 1000, 2000, 3000, 5000, 9999 };
        skillPointArray = new int[skills.GetComponentsInChildren<Button>().Length];
        skillValueArray = new float[skills.GetComponentsInChildren<Button>().Length];

        
        for (int i = 0; i < skillPointArray.Length; i++) {

            skillPointArray[i] = 0;
            skills.GetComponentsInChildren<Button>()[i].GetComponentsInChildren<Text>()[1].text = "0";// 設定技能點數
            skills.GetComponentsInChildren<Button>()[i].GetComponentsInChildren<Text>()[3].text = "$" + howMuch(0).ToString();

        }

        setMoney(999);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //設定技能點
    public void setMoney(int value)
    {
        totalMoney = value;
        skillPointText.text = value.ToString() + "根觸手";

    }


    //技能按鈕被按下 檢查是否有可用技能點 有責技能點-1 技能按鈕點數+1 發送事件更新按鈕數值
    public void onSkillButtonClicked(string str)
    {
        int skillIndex = strToNum(str);
        int price = howMuch(skillPointArray[skillIndex]);
        bool isEnough = true;
        //call 
        if (isEnough)
        {
            skillPointArray[skillIndex]++;
            skillPointText.text = totalMoney.ToString() + "根觸手";//更新view
            skills.GetComponentsInChildren<Button>()[skillIndex].GetComponentsInChildren<Text>()[1].text = skillPointArray[skillIndex].ToString();
            skills.GetComponentsInChildren<Button>()[skillIndex].GetComponentsInChildren<Text>()[3].text = "$" + howMuch(skillPointArray[skillIndex]).ToString();

            //switch (str)
            //{
            //    case "food":
            //        AbilityScoreInstance.instance.SetFoodsScore();
            //        break;
            //    case "drink":
            //        AbilityScoreInstance.instance.SetDrinksScore();
            //        break;
            //    case "cloth":
            //        AbilityScoreInstance.instance.SetApparelsScore();
            //        break;
            //    case "counter1":
            //        AbilityScoreInstance.instance.SetCounterResisitancePointPrecent();
            //        break;
            //    case "counter2":
            //        AbilityScoreInstance.instance.SetCounterResisitanceScorePrecent();
            //        break;
            //    case "counter3":
            //        AbilityScoreInstance.instance.SetAreaSpreadAdditioanlPoint();
            //        break;
            //}

        }
        else
        {
           // alertText.GetComponent<Animatior>().SetTrigger("alert");
        }
    }
  
    int howMuch(int levelIndex)
    {
        if (levelIndex >= moneyMap.Length) return moneyMap[moneyMap.Length-1];
        else return moneyMap[levelIndex];
    }
    int strToNum(string str)//不要重複數字就行
    {
  
        if (str == "food") return 0;
        else if (str == "drink") return 1;
        else if (str == "cloth") return 2;
        else if (str == "counter1") return 3;
        else if (str == "counter2") return 4;
        else if (str == "counter3") return 5;
        return 999;
    }
}
