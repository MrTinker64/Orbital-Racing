using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gravity
{
    public const float G = 6.674f;

    public static Vector2 Force(Vector3 pos1, Vector3 pos2, float m1, float m2)
    {
        Debug.Log("pos1: " + pos1 + ", pos2: " + pos2 + ", m1:" + m1 + ", m2:" + m2);

        Vector2 directionToPlanet = pos2 - pos1;
        float distanceSquared = directionToPlanet.sqrMagnitude;
        float gravityMagnitude = G * (m1 * m2) / distanceSquared;
        Vector2 gravityForce = directionToPlanet.normalized * gravityMagnitude;

        return gravityForce;
    }
}