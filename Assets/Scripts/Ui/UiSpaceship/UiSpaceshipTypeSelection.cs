using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiSpaceshipTypeSelection : MonoBehaviour
{
    private const SpaceshipType _defaultSpaceshipType = SpaceshipType.Default;
    public event UnityAction<SpaceshipType> OnSpaceshipTypeChange;

    [SerializeField]
    private Button _previousTypeButton;
    [SerializeField]
    private Button _nextTypeButton;
    private SpaceshipType _recentType;


    public void OnPreviousTypeButtonClicked()
    {
        if (_recentType == SpaceshipType.Default)
        {
            _recentType = SpaceshipType.DoubleTailed;
        }
        else
        {
            _recentType = _recentType - 1;
        }

        if (OnSpaceshipTypeChange != null)
        {
            OnSpaceshipTypeChange(_recentType);
        }
    }

    public void OnNextTypeButtonClicked()
    {
        if (_recentType == SpaceshipType.DoubleTailed)
        {
            _recentType = SpaceshipType.Default;
        }
        else
        {
            _recentType = _recentType + 1;
        }

        if (OnSpaceshipTypeChange != null)
        {
            OnSpaceshipTypeChange(_recentType);
        }
    }

    private void Awake()
    {
        _previousTypeButton.onClick.AddListener(OnPreviousTypeButtonClicked);
        _nextTypeButton.onClick.AddListener(OnNextTypeButtonClicked);
    }

    private void Start()
    {
        Setup();
    }

    private void OnDestroy()
    {
        _previousTypeButton.onClick.RemoveAllListeners();
        _nextTypeButton.onClick.RemoveAllListeners();
    }

    private void Setup()
    {
        _recentType = _defaultSpaceshipType;

        if (OnSpaceshipTypeChange != null)
        {
            OnSpaceshipTypeChange(_recentType);
        }
    }
}
