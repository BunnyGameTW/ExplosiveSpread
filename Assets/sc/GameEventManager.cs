using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {

    public float gameTime;
    public bool bGameStart;

    List<OctoGameType.GameEvent> gameEventSet;
    BoardcastText boardcastText;
    int eventCount;

    public void Init()
    {
        bGameStart = false;
        gameEventSet = new List<OctoGameType.GameEvent>();
        gameEventSet.Add(GameEventData.DrinksDefAddEvent);
        gameEventSet.Add(GameEventData.FoodsDefAddEvent);
        gameEventSet.Add(GameEventData.ApparelsDefAddEvent);

        gameEventSet.Add(GameEventData.DrinksDefSubtractEvent);
        gameEventSet.Add(GameEventData.FoodsDefSubtractEvent);
        gameEventSet.Add(GameEventData.ApparelsDefSubtractEvent);

        //gameEventSet.Add(GameEventData.ResisitanceStartEventLv1);
        //gameEventSet.Add(GameEventData.ResisitanceStartEventLv2);
        //gameEventSet.Add(GameEventData.ResisitanceStartEventLv3);

        eventCount = 1;
        boardcastText = FindObjectOfType<BoardcastText>();
    }

    public void GameStart(NonOctoStore oldstore)
    {
        if (bGameStart)
            return;
        bGameStart = true;

        OctoGameLoop.instance.octoStoreManager.CreateNewOctoStore(oldstore);
    }

    public void OnUpdate()
    {
        if(!OctoGameLoop.instance.resisitanceManager.IsGameOver())
            if (bGameStart)
                gameTime += Time.deltaTime;

        CheckGameEvent();
    }

    void CheckGameEvent()
    {
        if (gameTime > 120 * eventCount)
        {
            eventCount++;
            if (gameEventSet.Count != 0) {
                int rand = Random.Range(0, gameEventSet.Count);

                //send event
              
                boardcastText.spawnEventText(gameEventSet[rand].showText);
                AbilityScoreInstance.instance.SetStoreResisitanceScore(gameEventSet[rand].affectStoreType, gameEventSet[rand].affectScore);
                
                gameEventSet.Remove(gameEventSet[rand]);

            }

        }
    }

    public bool IsGameStart() { return bGameStart; }
}
