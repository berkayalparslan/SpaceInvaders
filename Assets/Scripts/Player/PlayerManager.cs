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
    private short _playerLivesLeft = _maxPlayerLives;
    private SpaceshipType _playerSpaceshipType;
    private SpaceshipColor _playerSpaceshipColor;

    public SpaceshipType PlayerSpaceshipType
    {
        get
        {
            return _playerSpaceshipType;
        }
    }

    public SpaceshipColor PlayerSpaceshipColor
    {
        get
        {
            return _playerSpaceshipColor;
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
        _uiManager.UiStartMenu.StartGameButton.onClick.AddListener(OnGameStart);
    }

    private void OnDestroy()
    {
        OnPlayerDeath -= OnPlayerDied;
        _uiManager.UiStartMenu.StartGameButton.onClick.RemoveAllListeners();
    }

    private void OnGameStart()
    {
        SetSpaceshipAppearance(_uiManager.UiSpaceshipSelection.RecentSpaceshipType, _uiManager.UiSpaceshipSelection.RecentSpaceshipColor);
        _uiManager.HideMainMenu();
        //todo ui manager show ingame hud
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

    private void SetSpaceshipAppearance(SpaceshipType type, SpaceshipColor color)
    {
        _playerSpaceshipType = type;
        _playerSpaceshipColor = color;
        Sprite sprite = _resourcesManager.GetSpriteBySpaceshipTypeAndColor(type, color);

        if (sprite != null)
        {
            _playerSpaceship.SetSprite(sprite);
        }
    }
}
