using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitVisualizer : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;
    public Rigidbody2D planetRigidbody;

    private LineRenderer lineRenderer;

    public int orbitResolution = 100; // How many points to calculate
    public float timeStep = 0.1f; // Time step for each point calculation

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = orbitResolution;
    }

    private void FixedUpdate()
    {
        DrawOrbit();
    }

    private void DrawOrbit()
    {
        Vector3[] orbitPath = new Vector3[orbitResolution];

        Vector2 previousPosition = shipRigidbody.position;
        Vector2 velocity = shipRigidbody.velocity;

        for (int i = 0; i < orbitResolution; i++)
        {
            Vector2 gravityForce = Gravity.Force(previousPosition, planetRigidbody.position, shipRigidbody.mass, planetRigidbody.mass);
            Vector2 acceleration = gravityForce / shipRigidbody.mass;
            velocity += acceleration * timeStep;
            previousPosition += velocity * timeStep;

            orbitPath[i] = new Vector3(previousPosition.x, previousPosition.y, 0f);
        }

        lineRenderer.SetPositions(orbitPath);
    }
}