using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScoreInstance: MonoBehaviour {

    [SerializeField]
    float totalScore;
    [SerializeField]
    float foodsScore;
    [SerializeField]
    float drinksScore;
    [SerializeField]
    float apparelsScore;

    [SerializeField]
    float foodsResisitanceScore;
    [SerializeField]
    float drinksResisitanceScore;
    [SerializeField]
    float apparelsResisitanceScore;

    [SerializeField]
    [Range(0, 0.75f)]
    float counterResisitanceScorePrecent;
    
  
    [SerializeField]
    [Range(0, 0.85f)]
    float counterResisitancePointPrecent;

    [SerializeField]
    [Range(0, 180f)]
    float areaSpreadAdditioanlPoint;

    public float GetTotalScore() { return totalScore; }
    public float GetFoodsScore() { return foodsScore; }
    public float GetDrinksScore() { return drinksScore; }
    public float GetApparelsScore() { return apparelsScore; }

    // no need 
    public float GetFoodsResisitanceScore() { return foodsResisitanceScore; }
    public float GetDrinksResisitanceScore() { return drinksResisitanceScore; }
    public float GetApparelsResisitanceScore() { return apparelsResisitanceScore; }
    public float GetStoreResisitanceScore(OctoGameType.StoreType type)
    {
        if (type == OctoGameType.StoreType.Apparels)
            return GetApparelsResisitanceScore();
        else if (type == OctoGameType.StoreType.Drinks)
            return GetDrinksResisitanceScore();
        else if (type == OctoGameType.StoreType.Foods)
            return GetFoodsResisitanceScore();
        else
        {
            Debug.Log("worong type");
            return 0;
        }
    }

    public float GetCounterResisitanceScorePrecent() { return counterResisitanceScorePrecent; }
    public float GetCounterResisitancePointPrecent() { return counterResisitancePointPrecent; }

    public float GetAreaSpreadAdditioanlPoint() { return areaSpreadAdditioanlPoint; }


    public float GetNonOctoStoreScore(OctoGameType.StoreType type)
    {
        if (type == OctoGameType.StoreType.Apparels)
            return apparelsScore;
        else if (type == OctoGameType.StoreType.Drinks)
            return drinksScore;
        else 
            return foodsScore;

    }

    public static AbilityScoreInstance instance;
    
    void Start()
    {
        instance = this;
        totalScore = 0;
        foodsScore = Random.Range(0, 50);
        drinksScore = Random.Range(0, 50);
        apparelsScore = Random.Range(0, 50);
    }

    public void SetTotalScore(float f) { totalScore += f; }
    public void SetFoodsScore(float f) { foodsScore += f; }
    public void SetDrinksScore(float f) { drinksScore += f; }
    public void SetApparelsScore(float f) { apparelsScore += f; }
    
    //max 75%
    public void SetCounterResisitanceScorePrecent(float f) {
        counterResisitanceScorePrecent += f;
        if (counterResisitanceScorePrecent > 0.75f)
            counterResisitanceScorePrecent = 0.75f;
    }

    //max 85%
    public void SetCounterResisitancePointPrecent(float f) {
        counterResisitancePointPrecent += f;
        if (counterResisitancePointPrecent > 0.85f)
            counterResisitancePointPrecent = 0.85f;
    }


    // max 180
    public void SetAreaSpreadAdditioanlPoint(float f)
    {
        areaSpreadAdditioanlPoint += f;
        if (areaSpreadAdditioanlPoint > 180)
            areaSpreadAdditioanlPoint = 180;
    }


    //no need
    public void SetFoodsResisitanceScore(float f) { foodsResisitanceScore += f; }
    public void SetDrinksResisitanceScore(float f) { drinksResisitanceScore += f; }
    public void SetApparelsResisitanceScore(float f) { apparelsResisitanceScore += f; }
    public void SetStoreResisitanceScore(OctoGameType.StoreType type, float f)
    {
        if (type == OctoGameType.StoreType.Apparels)
            SetApparelsResisitanceScore(f);
        else if (type == OctoGameType.StoreType.Drinks)
            SetDrinksResisitanceScore(f);
        else if (type == OctoGameType.StoreType.Foods)
            SetFoodsResisitanceScore(f);
        else
            Debug.Log("worong type");
    }


    private void Update()
    {
        print(OctoGameLoop.instance.resisitanceManager.IsGameOver());
        if (OctoGameLoop.instance.resisitanceManager.IsGameOver()) return;
        if (OctoGameLoop.instance.gameEventManager.bGameStart)
            totalScore += Time.deltaTime * 0.25f;
        
    } 

}
