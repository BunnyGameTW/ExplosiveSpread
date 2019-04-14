using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoStoreManager {

    public List<OctoStore> octoStoreSet;

    public OctoStoreManager()
    {
        octoStoreSet = new List<OctoStore>();
    }

    public void CreateNewOctoStore(IStoreUtility origonalStore)
    {
        GameObject g;
        if (origonalStore.storeLv < OctoGameType.StoreLv.Lv2)
            g = Object.Instantiate(OctoGameLoop.instance.OctoStorePrefab, origonalStore.transform.position, origonalStore.transform.rotation);
        else
            g = Object.Instantiate(OctoGameLoop.instance.OctoStorePrefab_big, origonalStore.transform.position, origonalStore.transform.rotation);

        g.transform.localScale = origonalStore.transform.localScale;
        OctoStore newStore = g.GetComponent<OctoStore>();
        newStore.Init(OctoGameType.StoreType.Octo, origonalStore.storeLv);
        OctoGameLoop.instance.octoStoreManager.octoStoreSet.Add(newStore);

        origonalStore.CallWhenOccupy();  //目前是移除串列後刪掉
                                         //通知 ResisitanceManager 計算是否開始抵制章魚燒店
        OctoGameLoop.instance.resisitanceManager.SetResisitanceLv();

        Debug.Log(origonalStore.gameObject.name  + "LV:" + ((int)origonalStore.storeLv + 1) + "被章魚燒併購了" );

    }

}
