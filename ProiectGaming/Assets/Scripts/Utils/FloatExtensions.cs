using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static bool InInterval(this float value, float left, float right, bool closedLeft = true, bool closedRight = true)
    {
        if (value < left)
        {
            return false;
        }
        // if left is not included in interval and value == left
        if (!closedLeft && value == left)
        {
            return false;
        }
        // if right is not included in interval and value == right
        if (value > right)
        {
            return false;
        }
        if (!closedRight && value == right)
        {
            return false;
        }
        return true;
    }

}
