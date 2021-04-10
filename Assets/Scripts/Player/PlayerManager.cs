using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    private const float _defaultMovementRange = 32.5f;
    private const short _numberOfLivesForPlayer = 3;

    private PlayerSpaceshipController _playerSpaceship;
    private UiManager _uiManager;
    [SerializeField]
    private PlayerCamera _playerCamera;
    private SpaceshipType _playerSpaceshipType;
    private SpaceshipColor _playerSpaceshipColor;
    private WaitForSeconds _waitBeforeRespawn = new WaitForSeconds(2f);
    private IEnumerator _respawnAfterWaiting;

    public UnityAction OnPlayerDeath;

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
        SetPlayerMovementBorders();
        SetPlayerLives(_numberOfLivesForPlayer);
        _uiManager.HideMainMenu();
        //todo ui manager show ingame hud
        _playerCamera.ChangeCameraToGameView();
        Managers.Instance.GameManager.StartGame();
    }

    public void PauseAndContinueGameAfterPlayerRespawn()
    {
        Managers.Instance.GameManager.PauseGameAndContinueWithDelay();
        RespawnWithDelay();
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

    private void SetPlayerMovementBorders()
    {
        _playerSpaceship.SetHorizontalMovementBorders(Vector2.zero, _defaultMovementRange);
    }

    private void SetPlayerLives(short numberOfLives)
    {
        _playerSpaceship.SetNumberOfLives(numberOfLives);
    }

    private void Awake()
    {
        _respawnAfterWaiting = RespawnAfterWaiting();
    }

    private void Start()
    {
        _playerSpaceship = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpaceshipController>();
        _uiManager = Managers.Instance.UiManager;
    }

    private void RespawnWithDelay()
    {
        StartCoroutine(_respawnAfterWaiting);
    }

    private IEnumerator RespawnAfterWaiting()
    {
        yield return _waitBeforeRespawn;
        _playerSpaceship.gameObject.SetActive(true);
    }
}
