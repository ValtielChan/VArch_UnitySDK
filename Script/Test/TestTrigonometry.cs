using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VArch.SDK.Geometry;

namespace VArch.SDK.Test
{
    public class TestTrigonometry : MonoBehaviour
    {
        public int width = 10;
        public int height = 5;
        public float hStep = 0.1f;
        public float vStep = 0.1f;
        public float baseOffset = 0.0f;
        public float radius = 5.0f;
        public bool centered = false;
        public bool hemisphere = false;

        private void OnDrawGizmos()
        {
            Vector3[] grid = Trigonometry.CreateGrid(width, height, hStep, vStep, baseOffset, radius, centered, hemisphere);

            foreach (Vector3 pos in grid)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(pos, 0.1f);
            }

            grid = Trigonometry.Create360Grid(width, height, vStep, radius, hemisphere);

            foreach (Vector3 pos in grid)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(pos, 0.1f);
            }
        }
    }
}