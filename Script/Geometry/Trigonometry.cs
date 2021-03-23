using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VArch.SDK.Geometry
{
    public class Trigonometry
    {
        public static Vector2 Position(float angleRad)
        {
            return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        public static Vector2 Position(int angleDeg)
        {
            float angleRad = (float)angleDeg * Mathf.Deg2Rad;
            return Position(angleRad);
        }

        public static Vector3[] CreateGrid(int width, int height, float hStep, float vStep, float baseOffset = 0.0f, float radius = 1.0f, bool centered = false, bool hemisphere = false)
        {
            List<Vector3> grid = new List<Vector3>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Center the grid side to side from 0
                    float angle = centered ? ((-hStep * (width-1)) / 2.0f) + (i * hStep) : (i * hStep);
                    float verticalAngle = baseOffset + (j * vStep);

                    Vector2 hPos = Position(angle);
                    Vector2 vPos = Position(verticalAngle);

                    Vector3 position;

                    // Position along hemisphere
                    if (hemisphere)
                    {
                        position = new Vector3(
                        hPos.x * radius * vPos.x,
                        vPos.y * radius,
                        hPos.y * radius * vPos.x);
                    }
                    else
                    {
                        position = new Vector3(
                        hPos.x * radius,
                        verticalAngle,
                        hPos.y * radius);
                    }

                    grid.Add(position);
                }
            }

            return grid.ToArray();
        }

        public static Vector3[] Create360Grid(int width, int height, float vStep, float radius = 1.0f, bool hemisphere = false, float baseOffset = 0.0f)
        {
            List<Vector3> grid = new List<Vector3>();

            float hStep = (2 * Mathf.PI) / (float)width;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    float angle = (i * hStep);
                    float verticalAngle = baseOffset + (j * vStep);

                    Vector2 hPos = Position(angle);
                    Vector2 vPos = Position(verticalAngle);

                    Vector3 position;

                    // Position along hemisphere
                    if (hemisphere)
                    {
                        position = new Vector3(
                        hPos.x * radius * vPos.x,
                        vPos.y * radius,
                        hPos.y * radius * vPos.x);
                    }
                    else
                    {
                        position = new Vector3(
                        hPos.x * radius,
                        verticalAngle,
                        hPos.y * radius);
                    }

                    grid.Add(position);
                }
            }

            return grid.ToArray();
        }
    }
}
