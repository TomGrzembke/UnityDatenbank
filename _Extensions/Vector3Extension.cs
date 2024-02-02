using UnityEngine;

public enum Axis
{
    X,
    Y,
    Z
}

public static class Vector3Extension
{

    public static Vector3 WithoutZ(this Vector3 target)
    {
        target.z = 0;
        return target;
    }

    public static Vector3 ChangeAxis(this Vector3 target, Axis axis, float value)
    {
        if (axis == Axis.X)
            target.x = value;
        else if (axis == Axis.Y)
            target.y = value;
        else if (axis == Axis.Z)
            target.z = value;

        return target;
    }
}