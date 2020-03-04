using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    Rigidbody2D PlanetRB;
    float orbitVelNum;
    bool firstPlanet = false;

    public float zeroRepelForce = -5f;

    private void Start()
    {
        PlanetRB = GetComponent<Rigidbody2D>();
        firstPlanet = true;
    }

    private void FixedUpdate()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Attract(Player);
    }

    void Attract(GameObject objToAttract)
    {
        bool tapped = GetComponent<changeGravity>().firstDoubleTap;
        Rigidbody2D PlayerRB = objToAttract.GetComponent<Rigidbody2D>();
        Vector2 direction = PlanetRB.position - PlayerRB.position;
        float distance = direction.magnitude;

        // Added a repelling force if planet mass is 0
        float planetMass = !tapped ? PlanetRB.mass : zeroRepelForce; // <-- Repel force
        //float planetMass = PlanetRB.mass;
        
        
        // Could add future stuff when planet is at 0 mass here
        if (planetMass < 0) {
            //Debug.Log("Success!");
        }

        // Changed the planetRB.mass to planetMass to incorporate the slight repel force when...
        // ... the mass of the planet is less than 1f
        float forceMagnitude =  ( (planetMass * PlayerRB.mass) / Mathf.Pow(distance, 2));
        Vector2 force = direction.normalized * forceMagnitude;
        orbitVelNum = Mathf.Sqrt(PlanetRB.mass/distance);


        //checks to see if player is orbiting the first planet and turns off the gravity of the other planets
        if (Mathf.Abs(PlayerRB.velocity.normalized.x + -direction.normalized.y) <= .5 && Mathf.Abs(PlayerRB.velocity.magnitude - orbitVelNum) <= .5 && firstPlanet==true)
        {
            Database.isOrbiting = true;            
            Database.orbitPlanetPos = PlanetRB.position;
            Attractor[] Planets = FindObjectsOfType<Attractor>();
            foreach (Attractor Planet in Planets)
            {
                if (Planet != this)
                {
                    Planet.GetComponent<Attractor>().enabled = false;
                }
            }
        }
        else
        {
            Database.isOrbiting = false;
        }

        //if the player is far enough away the orbit checking function gets turned off
        if (direction.magnitude > 5)
        {
            firstPlanet = false;
        }

        Debug.Log(Database.isOrbiting);
        PlayerRB.AddForce(force);
    }


}
