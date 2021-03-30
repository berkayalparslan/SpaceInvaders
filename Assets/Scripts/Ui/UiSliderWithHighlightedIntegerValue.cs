using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSliderWithHighlightedIntegerValue : UiSliderWithHighlightedValue<int>
{
    protected override void ConvertAndSetSliderValue(float value)
    {
        _highlightedSliderValue = (int)value;
    }
}
