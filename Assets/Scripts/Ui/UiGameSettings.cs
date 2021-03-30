using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiGameSettings : MonoBehaviour
{
    private const int _defaultNumberOfAiSpaceshipsPerRow = 10;
    private const float _defaultPlayerHorizontalSpeed = 5f;
    public event UnityAction OnGameStartedButtonClicked;
    [SerializeField]
    private UiSliderWithHighlightedIntegerValue _numberOfAiSpaceshipsPerRowSlider;
    [SerializeField]
    private UiSliderWithHighlightedFloatValue _playerHorizontalSpeedSlider;
    [SerializeField]
    private Button _startGameButton;
    private float _playerHorizontalSpeed;
    private int _numberOfSpaceshipsPerRow;

    public float PlayerHorizontalSpeed
    {
        get
        {
            return _playerHorizontalSpeed;
        }
    }

    public int NumberOfSpaceshipsPerRow
    {
        get
        {
            return _numberOfSpaceshipsPerRow;
        }
    }

    private void OnEnable()
    {
        _numberOfAiSpaceshipsPerRowSlider.SetDefaultValue(_defaultNumberOfAiSpaceshipsPerRow);
        _playerHorizontalSpeedSlider.SetDefaultValue(_defaultPlayerHorizontalSpeed);
        OnGameStartedButtonClicked = new UnityAction(StartGame);
        _startGameButton.onClick.AddListener(OnGameStartedButtonClicked);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(OnGameStartedButtonClicked);
        OnGameStartedButtonClicked = null;
    }

    private void StartGame()
    {
        _numberOfSpaceshipsPerRow = _numberOfAiSpaceshipsPerRowSlider.HighlightedValue;
        _playerHorizontalSpeed = _playerHorizontalSpeedSlider.HighlightedValue;
        Managers.Instance.AiSpaceshipsRowManager.SetNumberOfSpaceshipsPerRow();
        Managers.Instance.PlayerManager.StartGame();
    }
}
