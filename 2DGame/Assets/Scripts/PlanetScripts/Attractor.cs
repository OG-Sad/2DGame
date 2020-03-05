﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public float G = 1;

    Rigidbody2D PlanetRB, PlayerRB;
    float orbitVelNum, pi = Mathf.PI;
    Vector2 lastVelocity, lastPlayerPos;
    bool firstPlanet = false;

    GameObject Player;

    public float zeroRepelForce = -5f;

    private void Start()
    {
        PlanetRB = GetComponent<Rigidbody2D>();
        
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        firstPlanet = true;
    }

    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        float dist = Vector2.Distance(transform.position, Player.transform.position);

        float playerTheta = Mathf.Atan2(Player.transform.position.y - lastPlayerPos.y, Player.transform.position.x - lastPlayerPos.x);

        if (dist <= 4) {
            //Debug.Log(true);

            Vector2 acceleration = (PlayerRB.velocity - lastVelocity) / Time.fixedDeltaTime;
            Orbiting(acceleration, playerTheta, g(PlanetRB.mass, dist));
        }

        Attract(Player);
    
        lastVelocity = PlayerRB.velocity;
        lastPlayerPos = Player.transform.position;
    }

    void Attract(GameObject objToAttract)
    {
        bool tapped = GetComponent<changeGravity>().firstDoubleTap;
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

        //Debug.Log(Database.isOrbiting);
        PlayerRB.AddForce(force);
    }

    void Orbiting (Vector2 acc, float playTan, float G) {


        // Planet Pos
         // Planet Pos
        float m1X = transform.position.x;
        float m1Y = transform.position.y;

        // Player Pos
        float m2X = Player.transform.position.x;
        float m2Y = Player.transform.position.y;

      
        float playPlanTan = Mathf.Atan2(m2Y - m1Y, m2X - m1X);
        float angleSum = Mathf.Abs(playTan - playPlanTan) / pi;


        // Vector2 direction = PlanetRB.position - PlayerRB.position;

        // float forceMagnitude =  ( (PlanetRB.mass * PlayerRB.mass) / Mathf.Pow(dist, 2));
        // Vector2 force = direction.normalized * forceMagnitude;

        // float xComponent = force.x;
        // float yComponent = force.y;

        //Debug.Log("Not Ready");

        // Checks to see if the player's angle to the planet around 90 degrees
        if((1.4 < angleSum && angleSum < 1.6) || (0.4 < angleSum && angleSum < 0.6)) {
            
            // if (dist < lastDist) {
            //     yComponent = Mathf.Cos(playPlanTan) * force.magnitude * 1.001f;
            //     xComponent = Mathf.Sin(playPlanTan) * force.magnitude * 1.001f;
            // }
            // else if (dist > lastDist) {
            //     yComponent = Mathf.Cos(playPlanTan) * force.magnitude * .999f;
            //     xComponent = Mathf.Sin(playPlanTan) * force.magnitude * .999f;
        }


            // Vector2 forceApplied = new Vector2(xComponent, yComponent);
            
            
            
            
            //PlayerRB.AddForce(forceApplied);
            
            //Debug.Log("Ready to Orbit");
        
    }

    float g(float m1, float distance) {
        return (G * m1) / (distance * distance);
    }



}
