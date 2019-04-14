using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoGameAlgorthm
{

    public static float GetDefendScore(OctoGameType.StoreLv lv)
    {
        int iLv = (int)lv + 1;
        float randNum = Random.Range(0.85f, 1.35f);
        return Mathf.Pow(iLv,0.7f) * 100 * randNum;
    }

    public static float GetAttackScore(OctoGameType.StoreLv lv)
    {
        int iLv = (int)lv + 1;
        float randNum = Random.Range(0.7f, 1.2f);
        return Mathf.Pow(iLv, 0.7f) * 100 * randNum;
    }


    public void CalculateGameEventAffectScore(OctoGameType.StoreType type, float score)
    {
        if (type == OctoGameType.StoreType.All)
            return;
        else if (type == OctoGameType.StoreType.Apparels)
            AbilityScoreInstance.instance.SetApparelsResisitanceScore(score);
        else if (type == OctoGameType.StoreType.Foods)
            AbilityScoreInstance.instance.SetFoodsResisitanceScore(score);
        else if (type == OctoGameType.StoreType.Drinks)
            AbilityScoreInstance.instance.SetDrinksResisitanceScore(score);
        else
            return;
    }
}
