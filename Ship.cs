using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float shipMass;
    public Rigidbody2D shipRB;
    private Vector3 startPosition;

    private Planet planet;
    private float planetMass;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        setup();

        // ! Not sure if this finds the closest
        planet = FindObjectOfType<Planet>();
        planetMass = planet.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipRB.velocity += Vector2.up * 2;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            setup();
        }
    }

    // FixedUpdate is called consistently regardless of framerate
    void FixedUpdate()
    {
        shipRB.AddForce(Gravity.Force(transform.position, planet.transform.position, shipMass, planetMass));
    }

    void setup()
    {
        transform.position = startPosition;
        shipRB.velocity = Vector2.up * 5;
    }
}
