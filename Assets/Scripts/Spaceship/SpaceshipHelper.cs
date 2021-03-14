using System.Collections;
using System.Collections.Generic;

public class SpaceshipHelper
{
    public static SpaceshipColor GetSpaceshipColorMinValue()
    {
        SpaceshipColor[] colors = GetSpaceshipColorValues();
        return colors[0];
    }

    public static SpaceshipColor GetSpaceshipColorMaxValue()
    {
        SpaceshipColor[] colors = GetSpaceshipColorValues();
        return colors[colors.Length - 1];
    }

    public static SpaceshipType GetSpaceshipTypeMinValue()
    {
        SpaceshipType[] types = GetSpaceshipTypeValues();
        return types[0];
    }

    public static SpaceshipType GetSpaceshipTypeMaxValue()
    {
        SpaceshipType[] types = GetSpaceshipTypeValues();
        return types[types.Length - 1];
    }

    private static SpaceshipColor[] GetSpaceshipColorValues()
    {
        return (SpaceshipColor[])System.Enum.GetValues(typeof(SpaceshipColor));
    }

    private static SpaceshipType[] GetSpaceshipTypeValues()
    {
        return (SpaceshipType[])System.Enum.GetValues(typeof(SpaceshipType));
    }
}
