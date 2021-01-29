using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Utilities
{
    public static class VectorExtensions
    {
        public static Vector3 AddRandomAngle(this Vector3 vector, Vector3 axis, float minAngle, float maxAngle)
        {
            float angle = UnityEngine.Random.Range(minAngle, maxAngle);
            return Quaternion.AngleAxis(angle, axis) * vector;
        }
    }
}