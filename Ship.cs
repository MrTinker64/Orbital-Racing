using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float shipMass;
    public Rigidbody2D shipRB;
    public float thrustPower;
    public float torqueAmount;

    private Vector3 startPosition;

    private Planet planet;
    private float planetMass;

    private float distance;

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
        Vector2 toPlanet = (planet.transform.position - transform.position).normalized;

        distance = Vector3.Distance(transform.position, planet.transform.position);

        if (distance > 8)
        {
            setup();
        }

        // Keybindings

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shipRB.AddForce(transform.up * thrustPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shipRB.AddForce(-transform.up * thrustPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shipRB.AddForce(-transform.right * thrustPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shipRB.AddForce(transform.right * thrustPower, ForceMode2D.Impulse);
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
        this.Orient();
    }

    void Orient()
    {
        Vector2 directionToPlanet = (planet.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(directionToPlanet.y, directionToPlanet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward); // Subtracting 90 degrees because we want the ship to face perpendicular to the planet
    }

    void setup()
    {
        transform.position = startPosition;
        shipRB.velocity = Vector2.up * 5;
    }
}
