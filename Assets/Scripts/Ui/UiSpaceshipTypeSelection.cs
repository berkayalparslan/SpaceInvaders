using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiSpaceshipTypeSelection : MonoBehaviour
{
    public event UnityAction<SpaceshipType> OnSpaceshipTypeChange;

    [SerializeField]
    private Button _previousTypeButton;
    [SerializeField]
    private Button _nextTypeButton;
    private SpaceshipType _recentType;
    private SpaceshipColor _recentColor;


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
        //Setup();
    }

    private void OnDestroy()
    {
        _previousTypeButton.onClick.RemoveAllListeners();
        _nextTypeButton.onClick.RemoveAllListeners();
    }

    private void Setup()
    {
        _recentType = SpaceshipType.Default;

        if (OnSpaceshipTypeChange != null)
        {
            OnSpaceshipTypeChange(_recentType);
        }
    }
}
