using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSpaceshipSelection : MonoBehaviour
{
    private readonly SpaceshipColor _defaultSpaceshipColor = SpaceshipColor.Blue;
    [SerializeField]
    private UiSpaceshipTypeSelection _uiSpaceshipTypeSelection;
    [SerializeField]
    private UiSpaceshipColorSelection _uiSpaceshipColorSelection;
    [SerializeField]
    private Image _spaceshipImage;
    [SerializeField]
    private SpaceshipType _recentSpaceshipType;
    private SpaceshipColor _recentSpaceshipColor;

    public SpaceshipType RecentSpaceshipType
    {
        get
        {
            return _recentSpaceshipType;
        }
    }

    public SpaceshipColor RecentSpaceshipColor
    {
        get
        {
            return _recentSpaceshipColor;
        }
    }

    private void Awake()
    {
        _uiSpaceshipTypeSelection.OnSpaceshipTypeChange += OnSpaceshipTypeChange;
        _uiSpaceshipColorSelection.OnSpaceshipColorChange += OnSpaceshipColorChange;   
    }

    private void OnDestroy()
    {
        _uiSpaceshipTypeSelection.OnSpaceshipTypeChange -= OnSpaceshipTypeChange;
        _uiSpaceshipColorSelection.OnSpaceshipColorChange -= OnSpaceshipColorChange;
    }

    private void OnSpaceshipColorChange(SpaceshipColor color)
    {
        _recentSpaceshipColor = color;
        UpdateSpaceshipImage();
    }

    private void OnSpaceshipTypeChange(SpaceshipType type)
    {
        _recentSpaceshipType = type;
        UpdateSpaceshipImage();
    }

    private void UpdateSpaceshipImage()
    {
        Sprite sprite = Managers.Instance.ResourcesManager.GetSpriteBySpaceshipTypeAndColor(_recentSpaceshipType, _recentSpaceshipColor);

        if (sprite != null)
        {
            _spaceshipImage.sprite = sprite;
        }
    }
}
