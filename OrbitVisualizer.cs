using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

[RequireComponent(typeof(LineRenderer))]
public class OrbitVisualizer : MonoBehaviour
{
    public Rigidbody2D shipRB;
    public int orbitResolution = 100; // How many points to calculate
    public int orbitPredictTime = 2; // Seconds

    private LineRenderer lineRenderer;
    private Planet planet;

    private float shipMass;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        planet = FindObjectOfType<Planet>(); // Assumes there is only one Planet object
        shipMass = shipRB.mass;
    }

    void Update()
    {
        DrawOrbit();
    }

    void DrawOrbit()
    {
        Vector3[] positionsArray = new Vector3[orbitResolution];
        float timeStep = orbitPredictTime / (float)orbitResolution;

        Vector2 predictedVelocity = shipRB.velocity * math.PI;
        Vector2 predictedPosition = transform.position;

        for (int i = 0; i < orbitResolution; i++)
        {
            Vector2 gravityForce = Gravity.Force(predictedPosition, planet.transform.position, shipMass, planet.mass);
            Vector2 gravityAcceleration = gravityForce / shipMass;
            predictedVelocity += gravityAcceleration * timeStep;
            predictedPosition += predictedVelocity * timeStep;
            positionsArray[i] = new Vector3(predictedPosition.x, predictedPosition.y);
        }

        lineRenderer.positionCount = positionsArray.Length;
        lineRenderer.SetPositions(positionsArray);
    }
}