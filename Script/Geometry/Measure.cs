using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VArch.SDK.Geometry
{
    public class Measure
    {
        public static float HorizontalDistance(Vector3 p1, Vector3 p2)
        {
            float dist = Vector2.Distance(new Vector2(p1.x, p1.z), new Vector2(p2.x, p2.z));
            return dist;
        }
    }
}