using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResisitanceManager  {

    float resisitanceScore;
    bool bStartResisitance;

    readonly float MaxResisitanceScore = 300;

    //when reach 100 game over
    private float currentResisitancePoint;
    readonly float resisitancePointSpeedLv1 = 1f;
    readonly float resisitancePointSpeedLv2 = 2f;
    readonly float resisitancePointSpeedLv3 = 5f;

    public enum ResisitanceLV
    {
        LV0,
        LV1,
        LV2,
        LV3
    }
    public ResisitanceLV resisitanceLV;

    bool[] resisitanceLVOnceFlags;// Lv1 -> index0

    public ResisitanceManager()
    {
        bStartResisitance = false;
        resisitanceLV = ResisitanceLV.LV0;
        currentResisitancePoint = 0;

        resisitanceLVOnceFlags = new bool[3];
        for (int i = 0; i<resisitanceLVOnceFlags.Length; i++)
        {
            resisitanceLVOnceFlags[i]= false;
        }
    }


    public void SetResisitanceLv()
    {
        if (OctoGameLoop.instance.octoStoreManager.octoStoreSet.Count > (OctoGameLoop.instance.nonOctoStoreManager.totalStore * 0.9f)) {
            if (!resisitanceLVOnceFlags[(int)ResisitanceLV.LV3 -1])
            {
                resisitanceLV = ResisitanceLV.LV3;
                resisitanceScore = MaxResisitanceScore;

                resisitanceLVOnceFlags[(int)ResisitanceLV.LV3] = true;
                //send event 
                Debug.Log("Send Re 3 event");
            }
        }

        else if (OctoGameLoop.instance.octoStoreManager.octoStoreSet.Count > (OctoGameLoop.instance.nonOctoStoreManager.totalStore * 0.7f)) {

            if (!resisitanceLVOnceFlags[(int)ResisitanceLV.LV2 -1])
            {
                resisitanceLV = ResisitanceLV.LV2;
                resisitanceScore = MaxResisitanceScore * 0.6f;

                resisitanceLVOnceFlags[(int)ResisitanceLV.LV2] = true;
                //send event 
                Debug.Log("Send Re 2 event");
            }


        }
        else if (OctoGameLoop.instance.octoStoreManager.octoStoreSet.Count > (OctoGameLoop.instance.nonOctoStoreManager.totalStore * 0.4f)) {

            if (!resisitanceLVOnceFlags[(int)ResisitanceLV.LV1 - 1])
            {
                resisitanceLV = ResisitanceLV.LV1;
                resisitanceScore = MaxResisitanceScore * 0.2f;

                resisitanceLVOnceFlags[(int)ResisitanceLV.LV1] = true;
                //send event 
                Debug.Log("Send Re 1 event");
            }

         
            
        }

       
    }

    public void OnUpdate()
    {
        if (resisitanceLV == ResisitanceLV.LV1)
        {
            currentResisitancePoint += Time.deltaTime * resisitancePointSpeedLv1 *  (1- AbilityScoreInstance.instance.GetCounterResisitancePointPrecent());
        }
        else if (resisitanceLV == ResisitanceLV.LV2)
        {
            currentResisitancePoint += Time.deltaTime * resisitancePointSpeedLv2 * (1-AbilityScoreInstance.instance.GetCounterResisitancePointPrecent());
        }
        else if (resisitanceLV == ResisitanceLV.LV3)
        {
            currentResisitancePoint += Time.deltaTime * resisitancePointSpeedLv3 * (1- AbilityScoreInstance.instance.GetCounterResisitancePointPrecent());
        }

        //Debug.Log(currentResisitancePoint);
    }

    public bool IsGameOver()
    {
        return currentResisitancePoint > 100 ? (true) : (false);
    }

    //遊戲是否輸掉的判斷 100
    public float GetCurrentResisitancePoint() {
        return currentResisitancePoint > 100 ? (100) : (currentResisitancePoint);
    }

    //抵抗分數 目前最高150
    public float GetResisitanceScore() {
        return resisitanceScore * AbilityScoreInstance.instance.GetCounterResisitanceScorePrecent();

    }

}
