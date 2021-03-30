using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public UnityAction OnPlayerDeath;
    private const short _maxPlayerLives = 3;
    private PlayerSpaceshipController _playerSpaceship;
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


    public void StartGame()
    {
        SetSpaceshipAppearance(_uiManager.UiSpaceshipSelection.RecentSpaceshipType, _uiManager.UiSpaceshipSelection.RecentSpaceshipColor);
        SetPlayerHorizontalSpeed(_uiManager.UiGameSettings.PlayerHorizontalSpeed);
        _uiManager.HideMainMenu();
        //todo ui manager show ingame hud
        _playerCamera.ChangeCameraToGameView();
        Managers.Instance.GameManager.StartGame();
    }

    private void SetSpaceshipAppearance(SpaceshipType spaceshipType, SpaceshipColor spaceshipColor)
    {
        _playerSpaceshipType = spaceshipType;
        _playerSpaceshipColor = spaceshipColor;
        _playerSpaceship.InitSpaceshipBeforeActivating(spaceshipType, spaceshipColor);
    }

    private void SetPlayerHorizontalSpeed(float horizontalSpeed)
    {
        _playerSpaceship.SetMovementSpeed(new Vector2(horizontalSpeed, 0));
    }

    private void Awake()
    {
        OnPlayerDeath = new UnityAction(OnPlayerDied);
    }

    private void Start()
    {
        _playerSpaceship = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpaceshipController>();
        _resourcesManager = Managers.Instance.ResourcesManager;
        _uiManager = Managers.Instance.UiManager;
    }

    private void OnDestroy()
    {
        OnPlayerDeath -= OnPlayerDied;
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
        _playerSpaceship.gameObject.SetActive(true);
        Managers.Instance.GameManager.ContinueGame();
    }
}
