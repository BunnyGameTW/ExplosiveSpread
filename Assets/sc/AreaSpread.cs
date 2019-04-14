using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpread : MonoBehaviour
{

    OctoStore store;
    bool isActive;
    float spreadTimer;
    float effectScaleTimer; 
    float cuuretEffectScale; // 0-1
    float currentRangeScale; // 0-1


    public void Init(OctoStore _store)
    {
        store = _store;
        spreadTimer = 0;
        effectScaleTimer = 0;
    }


    public void ActiveAreaSpread()
    {
        isActive = true;
    }

    public void InactiveAreaSpread()
    {
        isActive = false;
    }

   
    public float GetAreaSpreadAddition(Vector2 pos)
    {
        Vector2 Obpos = new Vector2(transform.position.x, transform.position.z);
        float dst = Vector2.Distance(pos, Obpos);
        if (dst < currentRangeScale * AreaSpreadFlyweight.GetSpreadMaxRange(store.storeLv))
            return AreaSpreadFlyweight.GetMaxEffectPower(store.storeLv) * cuuretEffectScale + AbilityScoreInstance.instance.GetAreaSpreadAdditioanlPoint();
        return 0;
    }

    public void OnUpdate()
    {
        if (!isActive)
            return;


        spreadTimer += Time.deltaTime;
        effectScaleTimer += Time.deltaTime;
      
        cuuretEffectScale = Mathf.Lerp(0, 1, (effectScaleTimer/ AreaSpreadFlyweight.effectPowerScaleTime));
        currentRangeScale = Mathf.Lerp(0, 1, (spreadTimer / AreaSpreadFlyweight.spreadRangeTime));

        //print(cuuretEffectScale + "  ranges:" + currentRangeScale * AreaSpreadFlyweight.GetSpreadMaxRange(store.storeLv));
    }


    private void OnDrawGizmos()
    {

        Gizmos.color = new Vector4(1, 0, 0, cuuretEffectScale/2);
        //Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, currentRangeScale * AreaSpreadFlyweight.GetSpreadMaxRange(store.storeLv));
        
    }
}
