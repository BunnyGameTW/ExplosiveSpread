using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpreadFlyweight  {

    private static readonly float spreadMaxRangeDF  = 4;
    public static readonly float spreadRangeTime = 5;

    //[0-1]
    public static readonly  float effectPowerScaleTime = 10;

    public static float GetSpreadMaxRange(OctoGameType.StoreLv lv)
    {
        return Mathf.Pow(((int)lv + 1), 0.8f) * spreadMaxRangeDF; 
    }

    public static float GetMaxEffectPower(OctoGameType.StoreLv lv)
    {
        return Mathf.Pow(((int)lv + 1), 0.5f) * 50;
    }
}
