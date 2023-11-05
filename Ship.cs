using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float shipMass;
    public Rigidbody2D shipRB;

    private Planet planet;
    private float planetMass;
    private Vector3 planetPos;

    // Start is called before the first frame update
    void Start()
    {
        // ! Not sure if this finds the closest
        planet = FindObjectOfType<Planet>();
        planetMass = planet.mass;
        planetPos = planet.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipRB.velocity += Vector2.up;
        }
    }

    // FixedUpdate is called consistently regardless of framerate
    void FixedUpdate()
    {
        shipRB.AddForce(Gravity.Force(transform.position, planetPos, shipMass, planetMass));
    }
}
