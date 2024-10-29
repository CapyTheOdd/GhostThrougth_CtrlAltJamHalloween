using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }
    
    public GameState CurrentGameState { get; private set; }
    private GameState oldGameState;

    [SerializeField] private GameEvent OnGameStateChange;

    private void Awake() {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeState(GameState _newGameState) {
        if (_newGameState == CurrentGameState)return;

        oldGameState = CurrentGameState;

        switch (_newGameState)
        {
            case GameState.Playing:
                Time.timeScale = 1;
                break;
            case GameState.Gameover:
                StopTime();
                break;
            case GameState.Paused:
                StopTime();
                break;
        }

        OnGameStateChange.Raise(this, _newGameState);
        CurrentGameState = _newGameState;
    }
    private void StopTime() {
        Time.timeScale = 0;
    }

    private void Update() {
        if (Input.GetKeyDown
        (KeyCode.Escape)) {
            if (CurrentGameState == GameState.Paused) {
                ChangeState(oldGameState);
            } else {
                ChangeState(GameState.Paused);
            }
        }
    }
}

public enum GameState {
    Winning,
    Playing,
    Gameover,
    Paused
}