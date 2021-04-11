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
        float playerSpeed = _uiManager.UiGameSettings.PlayerHorizontalSpeed;
        int numberOfAiSpaceshipsPerRow = _uiManager.UiGameSettings.NumberOfSpaceshipsPerRow;

        SetSpaceshipAppearanceOnPlayerAndUi(_uiManager.UiSpaceshipSelection.RecentSpaceshipType, _uiManager.UiSpaceshipSelection.RecentSpaceshipColor);
        SetPlayerHorizontalSpeed(playerSpeed);
        SetPlayerMovementBorders();
        SetPlayerLives(_numberOfLivesForPlayer);
        Managers.Instance.PlayerScoreManager.SetScoreMultipliers(playerSpeed, numberOfAiSpaceshipsPerRow);
        _uiManager.HideMainMenu();
        _uiManager.ShowIngameHud();
        //todo ui manager show ingame hud
        _playerCamera.ChangeCameraToGameView();
        Managers.Instance.GameManager.StartGame();
    }

    public void PauseAndContinueGameAfterPlayerRespawn()
    {
        Managers.Instance.GameManager.PauseGameAndContinueWithDelay();
        RespawnWithDelay();
    }

    public void EndGame()
    {
        int playerScore = Managers.Instance.PlayerScoreManager.Score;
        int playerHighestScore = Managers.Instance.PlayerScoreManager.HighestScore;
        Managers.Instance.PlayerScoreManager.SaveIfPlayerAchievedNewHighestRecord();
        Managers.Instance.GameManager.EndGame();
        _uiManager.UiGameover.ShowPlayerScoreAndHighScore(playerScore, playerHighestScore);
    }

    private void SetSpaceshipAppearanceOnPlayerAndUi(SpaceshipType spaceshipType, SpaceshipColor spaceshipColor)
    {
        _playerSpaceshipType = spaceshipType;
        _playerSpaceshipColor = spaceshipColor;
        _playerSpaceship.InitSpaceshipBeforeActivating(spaceshipType, spaceshipColor);
        _uiManager.UiPlayerHud.InstantiatePlayerSpaceshipImagesAndSetTheirSprites(spaceshipType, spaceshipColor, _numberOfLivesForPlayer);
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

    private void Start()
    {
        _playerSpaceship = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpaceshipController>();
        _uiManager = Managers.Instance.UiManager;
    }

    private void RespawnWithDelay()
    {
        StopCoroutine(RespawnAfterWaiting());
        StartCoroutine(RespawnAfterWaiting());
    }

    private IEnumerator RespawnAfterWaiting()
    {
        yield return _waitBeforeRespawn;
        _playerSpaceship.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Managers.Instance.GameManager.GameIsOver && Input.anyKeyDown)
        {
            Managers.Instance.GameManager.RestartGame();
        }
    }
}
