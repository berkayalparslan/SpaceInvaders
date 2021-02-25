﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiSpaceshipColorButtons : MonoBehaviour
{
    public event UnityAction<SpaceshipColor> OnSpaceshipColorChange;
    private Dictionary<SpaceshipColor, UiSpaceshipColorButton> _buttons = new Dictionary<SpaceshipColor, UiSpaceshipColorButton>();
    private SpaceshipColor _recentSpaceshipColor;


    private void Start()
    {
        UiSpaceshipColorButton[] buttons = transform.GetComponentsInChildren<UiSpaceshipColorButton>();

        if (buttons.Length > 0)
        {
            foreach (UiSpaceshipColorButton button in buttons)
            {
                _buttons.Add(button.Color, button);
                button.OnButtonClick += OnSpaceshipColorButtonClicked;
            }
        }
        //Setup();
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            button.Value.OnButtonClick -= OnSpaceshipColorButtonClicked;
        }
    }

    private void Setup()
    {
        OnSpaceshipColorButtonClicked(SpaceshipColor.Blue);
    }

    private void OnSpaceshipColorButtonClicked(SpaceshipColor color)
    {
        _recentSpaceshipColor = color;

        if (OnSpaceshipColorChange != null)
        {
            OnSpaceshipColorChange(_recentSpaceshipColor);
        }
    }
}
