using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    private GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
        // ! Not sure if this finds the closest
        planet = GameObject.FindGameObjectWithTag("Planet");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
