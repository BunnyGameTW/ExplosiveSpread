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
    
    int totalSkillPoint = 0;
    int usedSkillPoint = 0;
    int[][] skillPointArray;
    float[][] skillValueArray;//點下去後座值的計算
    int skillIndex = 0;

    public Text skillPointText;
    public GameObject[] skillLabels;
    public event EventHandler<SkillButtonEventArgs> skillButtonClicked;

    // Use this for initialization
    void Start () {
        skillPointArray = new int[skillLabels.Length][];
        skillValueArray = new float[skillLabels.Length][];
        for (int i = 0; i < skillPointArray.Length; i++) {
            skillPointArray[i] = new int[skillLabels[i].GetComponentsInChildren<Button>().Length];
            skillValueArray[i] = new float[skillLabels[i].GetComponentsInChildren<Button>().Length];

            for (int j = 0; j < skillPointArray[i].Length; j++)
            {
                skillLabels[i].GetComponentsInChildren<Button>()[j].GetComponentsInChildren<Text>()[1].text = "0";
            }
        }

        setTotalSkillPoint(10);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //設定技能點
    public void setTotalSkillPoint(int value)
    {
        totalSkillPoint = value;
        skillPointText.text = usedSkillPoint.ToString() + "/" + value.ToString();

    }


    //技能按鈕被按下 檢查是否有可用技能點 有責技能點-1 技能按鈕點數+1 發送事件更新按鈕數值
    public void onSkillButtonClicked(string str)
    {
        if(usedSkillPoint < totalSkillPoint)
        {
            usedSkillPoint++;
            int skillMap = strToNum(str);
            skillPointArray[skillIndex][skillMap]++;
            skillPointText.text = usedSkillPoint.ToString() + "/" + totalSkillPoint.ToString();

            //更新view
            skillLabels[skillIndex].GetComponentsInChildren<Button>()[skillMap].GetComponentsInChildren<Text>()[1].text = skillPointArray[skillIndex][skillMap].ToString();

            //數值做計算
            float result = updateSkillValue(skillIndex, skillMap);

            //// 派發事件
            //if (this.skillButtonClicked != null)
            //{
            //    SkillButtonEventArgs arg = new SkillButtonEventArgs();
            //    arg.skillPoint = skillPointArray[skillIndex][skillMap];
            //    arg.skillName = str;
            //    this.skillButtonClicked(this, arg);
            //}
        }
        else
        {
            Debug.Log("沒有點數了");
        }
    }
    int strToNum(string str)//同一類技能不要重複數字就行
    {
  
        if (str == "food") return 0;
        else if (str == "drink") return 1;
        else if (str == "cloth") return 2;
        else if (str == "counter1") return 0;
        else if (str == "counter2") return 1;
        else if (str == "counter3") return 2;
        return 999;
    }

    //切換技能分業
    public void SwitchSkillLabel(string str)
    {
        if (str == "spread")
        {
            // 切到傳播類葉面
            skillIndex = 0;
            switchLabel();
            
        }
        else
        {
            skillIndex = 1;
            // 切到抗反擊葉面
            switchLabel();
        }
    }

    void switchLabel()
    {
        for (int i = 0; i < skillLabels.Length; i++)
        {
            if (skillIndex == i)
                skillLabels[i].SetActive(true);
            else
                skillLabels[i].SetActive(false);
        }
    }

    float updateSkillValue(int i,int j)
    {
        if (i == 0) {//傳播類
            skillValueArray[i][j] = skillPointArray[i][j] * LEVEL_VALUE;
        }
        else//抗解藥
        {
            skillValueArray[i][j] = skillPointArray[i][j] * LEVEL_VALUE;//TODO
        }
        return skillValueArray[i][j];
    }
}
