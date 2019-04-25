using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ShowStoreInPrecent : MonoBehaviour {

    Text precentText;
    float showPrecent;
    void Start () {
        showPrecent = retrnLimitDecimalNumber(OctoGameLoop.instance.octoStoreManager.GetTotalOctoStoreInPrecent() *100, 2);
        precentText = GetComponentInChildren<Text>();
    }
	

	void Update () {
        UpdateShowPrecent();

    }

    float retrnLimitDecimalNumber(float f,int i) {
        return (float)Math.Round(f, i, MidpointRounding.AwayFromZero);
    }

    void UpdateShowPrecent()
    {
        if (retrnLimitDecimalNumber(OctoGameLoop.instance.octoStoreManager.GetTotalOctoStoreInPrecent() * 100, 2) > showPrecent)
        {
            if(retrnLimitDecimalNumber(OctoGameLoop.instance.octoStoreManager.GetTotalOctoStoreInPrecent() * 100, 2) - showPrecent > 0.1f)
                showPrecent += 0.1f;
            else
                showPrecent += 0.01f;
        }
        else if (retrnLimitDecimalNumber(OctoGameLoop.instance.octoStoreManager.GetTotalOctoStoreInPrecent() * 100, 2) < showPrecent)
            showPrecent -= 0.01f;

        showPrecent = retrnLimitDecimalNumber(showPrecent, 2);
        precentText.text = Convert.ToString(showPrecent);
        if (showPrecent == 100.0f){
            FindObjectOfType<GameEnd>().setWin(true);
            OctoGameLoop.instance.isWin = true;
        }
    }
}
