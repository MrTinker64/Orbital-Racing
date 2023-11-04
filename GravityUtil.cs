using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GravityUtil
{
    public static Vector3 VectorBetween(Vector3 sourcePos, Vector3 targetPos, float magnitude)
    {
        // Calculate the direction from source to target
        Vector3 direction = targetPos - sourcePos;

        // Normalize the direction to get a unit vector
        Vector3 normalizedDirection = direction.normalized;

        // Scale the normalized direction by the desired magnitude
        return normalizedDirection * magnitude;
    }
}