using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private SpaceshipAppearance _playerSpaceship;
    private ResourcesManager _resourcesManager;
    private SpaceshipColor _recentSpaceshipColor;
    private SpaceshipType _recentSpaceshipType;


    private void Start()
    {
        _resourcesManager = Managers.Instance.ResourcesManager;
        Managers.Instance.UiManager.UiSpaceshipColorButtons.OnSpaceshipColorChange += OnSpaceshipColorChanged;
        Managers.Instance.UiManager.UiSpaceshipTypeSelection.OnSpaceshipTypeChange += OnSpaceshipTypeChanged;
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

    private void UpdateSpaceshipAppearance()
    {
        Sprite sprite = _resourcesManager.GetSpriteBySpaceshipTypeAndColor(_recentSpaceshipType, _recentSpaceshipColor);

        if (sprite != null)
        {
            _playerSpaceship.SetSprite(sprite);
        }
    }

}
