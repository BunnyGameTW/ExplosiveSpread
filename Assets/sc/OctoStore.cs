using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoStore : IStoreUtility {

    public float attackScore;

    AreaSpread areaSpread;

    public override void Init(OctoGameType.StoreType type, OctoGameType.StoreLv lv)
    {
        _storeType = type;
        _storeLv = lv;
        attackScore = OctoGameAlgorthm.GetAttackScore(lv);
       

        areaSpread = GetComponent<AreaSpread>();
        areaSpread.Init(this);
        areaSpread.ActiveAreaSpread();
    }


    public float GetAreaSpreadAddition(Vector2 pos)
    {
        return areaSpread.GetAreaSpreadAddition(pos);
    }

    public override void CallWhenOccupy()
    {
        OctoGameLoop.instance.octoStoreManager.octoStoreSet.Remove(this);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        areaSpread.OnUpdate();
    }
    public void deathAnimation()
    {
        this.gameObject.AddComponent<DeathAnimation>();
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
    }


   
}
