using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    Rigidbody2D PlanetRB;
    float orbitVelNum;

    public float zeroRepelForce = -5f;

    private void Start()
    {
        PlanetRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Attract(Player);
    }

    void Attract(GameObject objToAttract)
    {
        Rigidbody2D PlayerRB = objToAttract.GetComponent<Rigidbody2D>();
        Vector2 direction = PlanetRB.position - PlayerRB.position;
        float distance = direction.magnitude;

        // Added a repelling force if planet mass is 0 if planet mass is 0
        float planetMass = PlanetRB.mass > 1f ? PlanetRB.mass : zeroRepelForce; // <-- Repel force
        // Could add future stuff when planet is at 0 mass here
        if (planetMass < 0) {
            //Debug.Log("Success!");
        }

        // Changed the planetRB.mass to planetMass to incorporate the slight repel force when...
        // ... the mass of the planet is less than 1f
        float forceMagnitude =  ( (planetMass * PlayerRB.mass) / Mathf.Pow(distance, 2));

        //Debug.Log("Mass of Planet: "+ PlanetRB.mass);
        //Debug.Log("Mass of Player:" + PlayerRB.mass);
        Vector2 force = direction.normalized * forceMagnitude;
        orbitVelNum = Mathf.Sqrt(PlanetRB.mass/distance);
        //Debug.Log("force: " + force);
        //Debug.Log("Orbit Velocity: " + orbitVel);

        if (Mathf.Abs(PlayerRB.velocity.normalized.x + -direction.normalized.y) <= 1 && Mathf.Abs(PlayerRB.velocity.magnitude - orbitVelNum) <= .5)
        {
            Database.isOrbiting = true;
            Database.orbitPlanetPos = PlanetRB.position;

            Attractor[] Planets = FindObjectsOfType<Attractor>();
            foreach (Attractor Planet in Planets)
            {
                if (Planet != this)
                {
                    Planet.GetComponent<Attractor>().enabled=false;
                    //Planet.GetComponent<Rigidbody2D>().mass = 0;
                }
            }
        }
        else
        {
            Database.isOrbiting = false;
            Attractor[] Planets = FindObjectsOfType<Attractor>();
            foreach (Attractor Planet in Planets)
            {
                if (Planet != this)
                {
                    //Planet.GetComponent<Attractor>().enabled = true;
                }
            }
        }
        Debug.Log(Database.isOrbiting);
        PlayerRB.AddForce(force);

        //

        Vector2 force1 = new Vector2(3.527748f, 2);
        
        //Debug.Log("Velocity: "+ PlayerRB.velocity.magnitude);


        void Orbit()
        {
            float forceX = force.x;
            float forceY = force.y;
            Vector2 perpForce = new Vector2(forceY, -forceX);
            Vector2 orbitVel = perpForce.normalized * orbitVelNum;
            //PlayerRB.velocity = orbitVel;
            //Debug.Log("Perpendicular force: " + perpForce);
            //Debug.Log("force FLOAT: " + forceX + ", " + forceY);
        }
    }


}
