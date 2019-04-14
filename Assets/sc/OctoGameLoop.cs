using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoGameLoop : MonoBehaviour {

    OccupyComputer occupyComputer;
    public ResisitanceManager resisitanceManager;

    public OctoStoreManager octoStoreManager;
    public NonOctoStoreManager nonOctoStoreManager;

    public GameEventManager gameEventManager;

    public static OctoGameLoop instance;

    public TimeManager timeManager;

    // set up in inspector
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
