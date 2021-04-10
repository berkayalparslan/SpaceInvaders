using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private const float _gamePausedDuration = 2f;
    public event UnityAction OnGameStart;
    private bool _gamePaused;
    private bool _gameStarted = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(_gamePausedDuration);
    private IEnumerator _pauseGameAndContinueAfterWaiting;

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

    public void PauseGameAndContinueWithDelay()
    {
        StartCoroutine(_pauseGameAndContinueAfterWaiting);   
    }

    private IEnumerator PauseGameAndContinueAfterWaiting()
    {
        PauseGame();
        yield return _waitForSeconds;
        ContinueGame();
    }

    private void Awake()
    {
        _pauseGameAndContinueAfterWaiting = PauseGameAndContinueAfterWaiting();
    }
}
