using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VArch.SDK.Utility
{
    public class Utility
    {
        public static int LinearCood(Vector2Int size, Vector2Int coord)
        {
            return (coord.x * size.y) + coord.y;
        }

        public static void HorizontalLookAt(Transform transform, Transform target)
        {
            transform.LookAt(target);
            Quaternion newRot = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            transform.rotation = newRot;
        }
    }
}