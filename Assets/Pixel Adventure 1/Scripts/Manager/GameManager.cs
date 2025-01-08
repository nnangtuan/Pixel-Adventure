using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using static GameManager;

public enum GameState { Waiting, Game, Win, Lose}
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    public GameState gameState { get; private set; }
    private void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
        gameState = GameState.Game;
    }
    private void Udate()
    {
        
    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;

        IEnumerable<IGameStateListener> gameStateListeners =
            FindObjectsOfType<MonoBehaviour>()
            .OfType<IGameStateListener>();

        foreach (IGameStateListener gameStateListener in gameStateListeners)
        {
            gameStateListener.GameStateChangedCallback(gameState);
            Debug.Log("Notifying listener: " + gameStateListener);
        }
    }
    public interface IGameStateListener
    {
        void GameStateChangedCallback(GameState gameState);
    }
  
}
