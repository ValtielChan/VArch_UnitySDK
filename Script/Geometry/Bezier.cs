using UnityEngine;

namespace VArch.SDK.Geometry
{
    public class Bezier
    {
        public static Vector3 BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            float d = 1.0f - t;
            float dd = d * d;
            float tt = t * t;


            return (dd * p0) + (2 * d * t * p1) + (tt * p2);
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;

        //    for (float t = 0.0f; t < 1.0f; t += 0.1f)
        //    {
        //        Vector3 pos = BezierCurve(t);
        //        Gizmos.DrawSphere(pos, 0.05f);
        //    }
        //}
    }
}