﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonOctoStoreManager  {

    public List<NonOctoStore> nonOctoStoreSet;
    public int totalStore { get { return _totalStore; } }
    private int _totalStore;

    public NonOctoStoreManager()
    {
        nonOctoStoreSet = new List<NonOctoStore>(); 

        fundaction[] fundactions = GameObject.FindObjectsOfType<fundaction>();
        foreach (fundaction f in fundactions)
        {
            int randI = Random.Range(0, 3);
            NonOctoStore octoStore;
            GameObject g;
            if (randI == 1)
            {
                g = spwnStore(OctoGameLoop.instance.FoodsStorePrefab, f);
                octoStore = g.GetComponent<NonOctoStore>();
                octoStore.Init(OctoGameType.StoreType.Foods, f.storeLv);
            }
            else if (randI == 2)
            {
                g = spwnStore(OctoGameLoop.instance.DrinksStorePrefab, f);
                octoStore = g.GetComponent<NonOctoStore>();
                octoStore.Init(OctoGameType.StoreType.Drinks, f.storeLv);
            }
            else
            {
                g = spwnStore(OctoGameLoop.instance.ApparelsStorePrefab, f);
                octoStore = g.GetComponent<NonOctoStore>();
                octoStore.Init(OctoGameType.StoreType.Apparels, f.storeLv);
            }

            nonOctoStoreSet.Add(octoStore);

            _totalStore++;
        }
    }

    GameObject spwnStore(GameObject prefab, fundaction f)
    {
        GameObject g;
        g = Object.Instantiate(prefab, f.gameObject.transform.position, f.gameObject.transform.rotation);
        g.transform.localScale = f.gameObject.transform.localScale;
        return g;
    }


}