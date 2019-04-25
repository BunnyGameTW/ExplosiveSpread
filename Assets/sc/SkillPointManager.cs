using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointManager : MonoBehaviour {

    [SerializeField]
    float totalMoney;

    public float GetTotalMoney() { return totalMoney; }
    readonly float moneyGrowSpeedDf = 0.4f;

    readonly float specailSkillAddScore = 45;
   

    public void Init()
    {
        totalMoney = 15;
    }

    #region UI call
    public bool TryAddFoodsScore(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetFoodsScore(specailSkillAddScore);

        return true;
    }

    public bool TryAddDrinksScore(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetDrinksScore(specailSkillAddScore);
        return true;
    }

    public bool TryAddApparelsScore(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetApparelsScore(specailSkillAddScore);

        return true;
    }

    public bool TryAddTotalScore(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetTotalScore(specailSkillAddScore * 0.25f);

        return true;
    }

    public bool TryAddCounterResisitancePointPrecent(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetCounterResisitancePointPrecent(0.165f);

        return true;
    }

    public bool TryAddCounterResisitanceScorePrecent(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetCounterResisitanceScorePrecent(0.14f);

        return true;
    }

    public bool TryAddAreaSpreadAdditioanlPoint(float cost)
    {
        if (cost > totalMoney)
            return false;
        totalMoney -= cost;
        AbilityScoreInstance.instance.SetAreaSpreadAdditioanlPoint(40);

        return true;
    }

    #endregion //end UI call

    public void OnUpdate()
    {
        calculateMoney();
    }


    void calculateMoney()
    {
        if (OctoGameLoop.instance.resisitanceManager.IsGameOver()) return;

        int totalLvCount = 0;
        foreach (OctoStore store in OctoGameLoop.instance.octoStoreManager.octoStoreSet)
        {
            totalLvCount += (int)store.storeLv + 1;
        }

        if (totalLvCount == 0)
            return;

        float addMoney = totalLvCount + 1;
        addMoney = Mathf.Pow(addMoney, 1.2f) * moneyGrowSpeedDf * Time.deltaTime; ; //???

        totalMoney += addMoney;
    }
}
