using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEscapeMenu : MonoBehaviour
{
    [SerializeField]
    private Button _continueButton;
    [SerializeField]
    private Button _toggleSoundButton;
    [SerializeField]
    private Button _restartGameButton;
    [SerializeField]
    private Button _exitGameButton;


    private void OnEnable()
    {
        Managers.Instance.GameManager.ForcePauseGame();
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _toggleSoundButton.onClick.AddListener(OnToggleSoundButtonClick);
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClick);
        _exitGameButton.onClick.AddListener(OnExitGameButtonClick);
    }

    private void OnDisable()
    {
        Managers.Instance.GameManager.ContinueGameAndRemoveForcedPause();
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _toggleSoundButton.onClick.RemoveListener(OnToggleSoundButtonClick);
        _restartGameButton.onClick.RemoveListener(OnRestartGameButtonClick);
    }

    private void OnContinueButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void OnToggleSoundButtonClick()
    {

    }

    private void OnRestartGameButtonClick()
    {
        Managers.Instance.GameManager.RestartGame();
    }

    private void OnExitGameButtonClick()
    {
        Managers.Instance.GameManager.ExitGame();
    }
}
