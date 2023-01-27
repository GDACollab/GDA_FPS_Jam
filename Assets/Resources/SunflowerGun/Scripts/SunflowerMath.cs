using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SunflowerMath
{
    // factor == 0: back to b value / no smoothing
    // smaller factors are faster lerps
    // factor == 1: back to a value / infinite smoothing
    // larger factors are slower lerps
    public static float Approach(float a, float b, float factor, float dt)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Pow(factor, dt));
    }

}