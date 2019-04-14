using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoGameLoop : MonoBehaviour {

    OccupyComputer occupyComputer;
    [HideInInspector]
    public ResisitanceManager resisitanceManager;

    [HideInInspector]
    public OctoStoreManager octoStoreManager;
    [HideInInspector]
    public NonOctoStoreManager nonOctoStoreManager;

    [HideInInspector]
    public GameEventManager gameEventManager;

    public static OctoGameLoop instance;

    public TimeManager timeManager;

    // set up in inspector
    public GameObject FoodsStorePrefab_big;
    public GameObject OctoStorePrefab_big;
    public GameObject DrinksStorePrefab_big;
    public GameObject ApparelsStorePrefab_big;

    public GameObject FoodsStorePrefab;
    public GameObject OctoStorePrefab;
    public GameObject DrinksStorePrefab;
    public GameObject ApparelsStorePrefab;

    private void Awake()
    {
        instance = this;
        occupyComputer = new OccupyComputer();

        octoStoreManager = new OctoStoreManager();
        nonOctoStoreManager = new NonOctoStoreManager();

        resisitanceManager = new ResisitanceManager();

        gameEventManager = FindObjectOfType<GameEventManager>();
        gameEventManager.Init();

        timeManager = gameObject.AddComponent<TimeManager>();
        timeManager.Init();
    }
	
	void Update ()
    {
        occupyComputer.OnUpdate();

        gameEventManager.OnUpdate();

        resisitanceManager.OnUpdate();

        timeManager.OnUpdate();
    }
}
