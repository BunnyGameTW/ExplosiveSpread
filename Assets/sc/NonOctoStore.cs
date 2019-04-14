using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonOctoStore : IStoreUtility {

    public float defendScore;
    
    public override void Init(OctoGameType.StoreType type, OctoGameType.StoreLv lv)
    {
        _storeType = type;
        _storeLv = lv;
        defendScore = OctoGameAlgorthm.GetDefendScore(storeLv);
       

    }

    public override void CallWhenOccupy()
    {
        OctoGameLoop.instance.nonOctoStoreManager.nonOctoStoreSet.Remove(this);
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        OctoGameLoop.instance.gameEventManager.GameStart(this);
    }
}
