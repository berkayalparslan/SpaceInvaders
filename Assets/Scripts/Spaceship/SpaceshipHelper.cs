using System.Collections;
using System.Collections.Generic;

public class SpaceshipHelper
{
    public static int GetColorsCount()
    {
        return GetSpaceshipColors().Length;
    }
    public static SpaceshipColor GetSpaceshipColorMinValue()
    {
        SpaceshipColor[] colors = GetSpaceshipColors();
        return colors[0];
    }

    public static SpaceshipColor GetSpaceshipColorMaxValue()
    {
        SpaceshipColor[] colors = GetSpaceshipColors();
        return colors[colors.Length - 1];
    }

    public static SpaceshipType GetSpaceshipTypeMinValue()
    {
        SpaceshipType[] types = GetSpaceshipTypes();
        return types[0];
    }

    public static SpaceshipType GetSpaceshipTypeMaxValue()
    {
        SpaceshipType[] types = GetSpaceshipTypes();
        return types[types.Length - 1];
    }

    public static SpaceshipColor[] GetSpaceshipColors()
    {
        return (SpaceshipColor[])System.Enum.GetValues(typeof(SpaceshipColor));
    }

    public static SpaceshipType[] GetSpaceshipTypes()
    {
        return (SpaceshipType[])System.Enum.GetValues(typeof(SpaceshipType));
    }
}
