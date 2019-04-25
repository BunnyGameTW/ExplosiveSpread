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
    AudioSource audio;
    // Use this for initialization
    void Start () {
        moneyMap = new int[] { 15, 100, 300, 800, 1200, 1800, 2100, 2500, 2800, 3000};
        skillPointArray = new int[skills.GetComponentsInChildren<Button>().Length];
        skillValueArray = new float[skills.GetComponentsInChildren<Button>().Length];
        audio = GetComponent<AudioSource>();


        for (int i = 0; i < skillPointArray.Length; i++) {

            skillPointArray[i] = 0;
            skills.GetComponentsInChildren<Button>()[i].GetComponentsInChildren<Text>()[0].text = "0";// 設定技能點數
            skills.GetComponentsInChildren<Button>()[i].GetComponentsInChildren<Text>()[1].text = howMuch(0).ToString();
            skills.GetComponentsInChildren<Button>()[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        setMoney((int)OctoGameLoop.instance.skillPointManager.GetTotalMoney());
    }
	
	// Update is called once per frame
	void Update () {
        setMoney((int)OctoGameLoop.instance.skillPointManager.GetTotalMoney());
    }

    //設定技能點
    public void setMoney(int value)
    {
        totalMoney = value;
        skillPointText.text = value.ToString();

    }


    //技能按鈕被按下
    public void onSkillButtonClicked(string str)
    {
        int skillIndex = strToNum(str);
        int price = howMuch(skillPointArray[skillIndex]);
        
        bool isEnough = false;
        switch (str)
        {
            case "food":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddFoodsScore(price);
                break;
            case "drink":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddDrinksScore(price);
                break;
            case "cloth":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddApparelsScore(price);
                break;
            case "counter1":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddTotalScore(price);
                break;
            case "counter2":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddCounterResisitancePointPrecent(price);
                break;
            case "counter3":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddAreaSpreadAdditioanlPoint(price);
                break;
            case "counter4":
                isEnough = OctoGameLoop.instance.skillPointManager.TryAddCounterResisitanceScorePrecent(price);
                break;
        }
        //call 
        if (isEnough)
        {
            setMoney((int)OctoGameLoop.instance.skillPointManager.GetTotalMoney());
            skillPointArray[skillIndex]++;
            skillPointText.text = totalMoney.ToString();//更新view
            skills.GetComponentsInChildren<Button>()[skillIndex].GetComponentsInChildren<Text>()[0].text = skillPointArray[skillIndex].ToString();
            skills.GetComponentsInChildren<Button>()[skillIndex].GetComponentsInChildren<Text>()[1].text = howMuch(skillPointArray[skillIndex]).ToString();
        }
        else
        {
           
            audio.Play();
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
        else if (str == "counter4") return 6;
        return 999;
    }
}
