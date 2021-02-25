using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiColorHelper
{
    public static Color GetColor(SpaceshipColor color)
    {
        switch (color)
        {
            case SpaceshipColor.Blue:
                return Color.blue;
            case SpaceshipColor.Green:
                return Color.green;
            case SpaceshipColor.NavyBlue:
                return new Color(0, 0, 128);
            case SpaceshipColor.Orange:
                return new Color(265, 165, 0);
            case SpaceshipColor.Purple:
                return new Color(128, 0, 128);
            case SpaceshipColor.Red:
                return Color.red;
            case SpaceshipColor.Yellow:
                return Color.yellow;
            default:
                throw new System.Exception("not possible case?");
        }
    }
}
