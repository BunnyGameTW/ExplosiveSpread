using System.Collections;
using System.Collections.Generic;

public class OctoGameType  {

    public enum StoreType
    {
        Octo,
        Foods,
        Drinks,
        Apparels,
        All
    }

    public enum StoreLv
    {
        Lv1,
        Lv2,
        Lv3
    }

    public struct GameEvent
    {
        public string showText;
        public StoreType affectStoreType;
        public float affectScore;

        public GameEvent(string _showText, StoreType _affectStoreType, float _affectScore)
        {
            showText = _showText;
            affectStoreType = _affectStoreType;
            affectScore = _affectScore;
        }
    }
  


}
