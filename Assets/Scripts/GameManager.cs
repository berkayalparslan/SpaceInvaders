using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnGameStart;
    private bool _gamePaused;
    private bool _gameStarted = false;


    private void Awake()
    {
        
    }

    public void StartGame()
    {
        _gameStarted = true;
        _gameStarted = false;

        if (OnGameStart != null)
        {
            OnGameStart.Invoke();
        }
    }

}
