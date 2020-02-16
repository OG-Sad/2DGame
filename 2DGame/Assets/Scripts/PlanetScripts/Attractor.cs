using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    Rigidbody2D PlanetRB;
    float orbitVel;

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
        orbitVel = Mathf.Sqrt(PlanetRB.mass/distance);
        //Debug.Log("force: " + force);
        //Debug.Log("Orbit Velocity: " + orbitVel);

        //Mathf.Sqrt(PlanetRB.mass*((2/distance)-1))
        //float angle = Mathf.Atan2(force.y, force.x);
        //force.x= force.x+Mathf.Sin(angle) * orbitVel;
        //force.y = force.y+Mathf.Sin(angle) * orbitVel;

        Vector2 force1 = new Vector2(3.527748f, 2);
        PlayerRB.AddForce(force);
        //Debug.Log("Velocity: "+ PlayerRB.velocity.magnitude);
    }


}
