using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStoreUtility : MonoBehaviour {

    public abstract void Init(OctoGameType.StoreType type, OctoGameType.StoreLv lv);

    public abstract void CallWhenOccupy();

    public OctoGameType.StoreType storeType { get { return _storeType; } }
    protected OctoGameType.StoreType _storeType;

    public OctoGameType.StoreLv storeLv { get { return _storeLv; } }
    protected OctoGameType.StoreLv _storeLv;

}
