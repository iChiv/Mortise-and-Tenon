using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        StartMenu,
        Level1,
        Level1Complete,
        Level2,
        Level2Complete,
        GameOver
    }

    private GameState currentState = GameState.StartMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.StartMenu:
                //bgm
                break;
            case GameState.Level1:
                //change player position
                break;
            case GameState.Level1Complete:
                //animation
                //Load Level2
                //Change player position
                break;
            case GameState.Level2:
                //new guidebook
                
                break;
            case GameState.Level2Complete:
                //win
                break;
            case GameState.GameOver:
                //Do we have this situation?
                break;
        }
    }
}
