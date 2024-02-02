using UnityEngine;

public enum ColorChannels
{
    R,
    G,
    B,
    A
}

public static class ColorExtensions
{
    public static Color ChangeChannel(this Color target, ColorChannels channels, float value)
    {
        if (channels == ColorChannels.R)
            target.r = value;
        else if (channels == ColorChannels.G)
            target.g = value;
        else if (channels == ColorChannels.B)
            target.b = value;
        else if (channels == ColorChannels.A)
            target.a = value;

        return target;
    }
}