using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public UnityAction OnPlayerDeath;
    private const short _maxPlayerLives = 3;
    private GameObject _player;
    [SerializeField]
    private SpaceshipAppearance _playerSpaceship;
    private ResourcesManager _resourcesManager;
    private UiManager _uiManager;
    [SerializeField]
    private PlayerCamera _playerCamera;
    private SpaceshipColor _recentSpaceshipColor;
    private SpaceshipType _recentSpaceshipType;
    private short _playerLivesLeft = _maxPlayerLives;

    public SpaceshipType RecentSpaceshipType
    {
        get
        {
            return _recentSpaceshipType;
        }
    }

    private void Awake()
    {
        OnPlayerDeath = new UnityAction(OnPlayerDied);
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _resourcesManager = Managers.Instance.ResourcesManager;
        _uiManager = Managers.Instance.UiManager;
        _uiManager.UiSpaceshipColorButtons.OnSpaceshipColorChange += OnSpaceshipColorChanged;
        _uiManager.UiSpaceshipTypeSelection.OnSpaceshipTypeChange += OnSpaceshipTypeChanged;
        _uiManager.UiStartMenu.StartGameButton.onClick.AddListener(OnGameStart);
        _recentSpaceshipColor = SpaceshipColor.Blue;
        _recentSpaceshipType = SpaceshipType.Default;
    }

    private void OnDestroy()
    {
        _uiManager.UiSpaceshipColorButtons.OnSpaceshipColorChange -= OnSpaceshipColorChanged;
        _uiManager.UiSpaceshipTypeSelection.OnSpaceshipTypeChange -= OnSpaceshipTypeChanged;
        OnPlayerDeath -= OnPlayerDied;
        _uiManager.UiStartMenu.StartGameButton.onClick.RemoveAllListeners();
    }

    private void OnSpaceshipColorChanged(SpaceshipColor color)
    {
        _recentSpaceshipColor = color;
        UpdateSpaceshipAppearance();
    }

    private void OnSpaceshipTypeChanged(SpaceshipType spaceshipType)
    {
        _recentSpaceshipType = spaceshipType;
        UpdateSpaceshipAppearance();
    }

    private void OnGameStart()
    {
        _uiManager.HideMainMenuUi();
        _playerCamera.ChangeCameraToGameView();
        Managers.Instance.GameManager.StartGame();
    }

    private void OnPlayerDied()
    {
        _playerLivesLeft--;

        if (!HasLivesLeft())
        {
            //gameover
            return;
        }
        StartCoroutine(PauseGameAndContinueWithDelay());
    }

    private bool HasLivesLeft()
    {
        return _playerLivesLeft > 0;
    }

    private IEnumerator PauseGameAndContinueWithDelay()
    {
        Managers.Instance.GameManager.PauseGame();
        yield return new WaitForSeconds(2);
        _player.gameObject.SetActive(true);
        Managers.Instance.GameManager.ContinueGame();
    }

    private void UpdateSpaceshipAppearance()
    {
        Sprite sprite = _resourcesManager.GetSpriteBySpaceshipTypeAndColor(_recentSpaceshipType, _recentSpaceshipColor);

        if (sprite != null)
        {
            _playerSpaceship.SetSprite(sprite);
        }
    }
}
