using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private SpaceshipAppearance _playerSpaceship;
    private ResourcesManager _resourcesManager;
    private UiManager _uiManager;
    [SerializeField]
    private PlayerCamera _playerCamera;
    private SpaceshipColor _recentSpaceshipColor;
    private SpaceshipType _recentSpaceshipType;


    private void Start()
    {
        _resourcesManager = Managers.Instance.ResourcesManager;
        _uiManager = Managers.Instance.UiManager;
        _uiManager.UiSpaceshipColorButtons.OnSpaceshipColorChange += OnSpaceshipColorChanged;
        _uiManager.UiSpaceshipTypeSelection.OnSpaceshipTypeChange += OnSpaceshipTypeChanged;
        _uiManager.UiStartMenu.StartGameButton.onClick.AddListener(OnGameStart);
        _recentSpaceshipColor = SpaceshipColor.Blue;
        _recentSpaceshipType = SpaceshipType.Default;
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

    private void UpdateSpaceshipAppearance()
    {
        Sprite sprite = _resourcesManager.GetSpriteBySpaceshipTypeAndColor(_recentSpaceshipType, _recentSpaceshipColor);

        if (sprite != null)
        {
            _playerSpaceship.SetSprite(sprite);
        }
    }

}
