using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    private float shipMass;

    private Planet planet;
    private float planetMass;

    // Start is called before the first frame update
    void Start()
    {
        // ! Not sure if this finds the closest
        planet = FindObjectOfType<Planet>();
        planetMass = planet.mass;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
