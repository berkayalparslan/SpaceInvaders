using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class UiSliderWithHighlightedValue<T> : MonoBehaviour
{
    protected T _highlightedSliderValue;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TMP_Text _highlightedValueText;
    

    public T HighlightedValue
    {
        get
        {
            return _highlightedSliderValue;
        }
    }

    protected abstract void ConvertAndSetSliderValue(float value);

    public void SetDefaultValue(float defaultValue)
    {
        _slider.value = defaultValue;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(UpdateHighlightedValue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(UpdateHighlightedValue);
    }

    private void UpdateHighlightedValue(float newValue)
    {
        ConvertAndSetSliderValue(newValue);
        _highlightedValueText.text = _highlightedSliderValue.ToString();
    }
}
