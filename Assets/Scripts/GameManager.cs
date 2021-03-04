using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public event UnityAction OnGameStart;
    private bool _gamePaused;
    private bool _gameStarted = false;

    public bool GameStarted
    {
        get
        {
            return _gameStarted;
        }
    }
    
    public bool GameIsRunning
    {
        get
        {
            return _gameStarted && !_gamePaused;
        }
    }

    private void Awake()
    {
        
    }

    public void StartGame()
    {
        _gameStarted = true;
        _gamePaused = false;

        if (OnGameStart != null)
        {
            OnGameStart();
        }
    }

    public void PauseGame()
    {
        _gamePaused = true;
    }

    public void ContinueGame()
    {
        _gamePaused = false;
    }

}
