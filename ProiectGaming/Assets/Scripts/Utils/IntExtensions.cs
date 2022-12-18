using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtensions
{
    public static bool InInterval(this int value, int left, int right, bool closedLeft = true, bool closedRight = true)
    {
        return ((float)value).InInterval(left, right, closedLeft, closedRight);
    }
}
