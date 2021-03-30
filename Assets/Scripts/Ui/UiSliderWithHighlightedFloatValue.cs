using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSliderWithHighlightedFloatValue : UiSliderWithHighlightedValue<float>
{
    protected override void ConvertAndSetSliderValue(float value)
    {
        _highlightedSliderValue = value;
    }
}
