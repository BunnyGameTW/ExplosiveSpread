using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupyComputer {

    public OccupyComputer()
    {

    }


    public void OnUpdate()
    {
        if (OctoGameLoop.instance.octoStoreManager.octoStoreSet.Count == 0)
            return;

        bool bBtreak = false; //replace only one store in one frame

        foreach (OctoStore store in OctoGameLoop.instance.octoStoreManager.octoStoreSet)
        {
            foreach (NonOctoStore nonOctoStore in OctoGameLoop.instance.nonOctoStoreManager.nonOctoStoreSet)
            {
                
                //最後分數  = 總分 + 該科技分數 + 地緣分數 - 抵抗分數 - 該科技抵抗分數(事件影響)

                Vector2 pos = new Vector2(nonOctoStore.gameObject.transform.position.x, nonOctoStore.gameObject.transform.position.z);
                float finalAttackScore = store.GetAreaSpreadAddition(pos) + AbilityScoreInstance.instance.GetTotalScore() 
                    + AbilityScoreInstance.instance.GetNonOctoStoreScore(nonOctoStore.storeType) - OctoGameLoop.instance.resisitanceManager.GetResisitanceScore() 
                    - AbilityScoreInstance.instance.GetStoreResisitanceScore(nonOctoStore.storeType);

                if (finalAttackScore > nonOctoStore.defendScore)
                {
                    OctoGameLoop.instance.octoStoreManager.CreateNewOctoStore(nonOctoStore);
                    bBtreak = true;
                    break;
               }
            }

            if (bBtreak)
                break;
        }
    }

   
}
