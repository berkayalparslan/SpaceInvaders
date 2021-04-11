using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float _gamePausedDuration = 2f;
    public event UnityAction OnGameStart;
    private bool _gamePaused;
    private bool _gameStarted;
    private bool _gameOver;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(_gamePausedDuration);
    private bool _forceGamePause;

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

    public bool GameIsOver
    {
        get
        {
            return _gameStarted && _gamePaused && _gameOver;
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

    public void ForcePauseGame()
    {
        _forceGamePause = true;
        PauseGame();
    }

    public void PauseGame()
    {
        _gamePaused = true;
    }

    public void ContinueGameAndRemoveForcedPause()
    {
        _forceGamePause = false;
        ContinueGame();
    }

    public void ContinueGame()
    {
        if (!_forceGamePause)
        {
            _gamePaused = false;
        }
    }

    public void EndGame()
    {
        _gamePaused = true;
        _gameOver = true;
    }

    public void PauseGameAndContinueWithDelay()
    {
        StopCoroutine(PauseGameAndContinueAfterWaiting());
        StartCoroutine(PauseGameAndContinueAfterWaiting());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator PauseGameAndContinueAfterWaiting()
    {
        PauseGame();
        yield return _waitForSeconds;
        ContinueGame();
    }
}
