using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EntityManager : MonoBehaviour, IGameStateListener
{

    protected bool canActive;
    protected virtual void Update()
    {
        if (!canActive)
            return;
    }
    public void GameStateChangedCallback(GameState gameState)
    {
        if (gameState==GameState.Game)
            canActive = true;
        else 
            canActive = false;
    }
}
