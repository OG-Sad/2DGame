using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public float G = 1;

    public GameObject OrbitRing;

    Rigidbody2D PlanetRB, PlayerRB;
    float orbitVelNum, pi = Mathf.PI, lastPlayPlanTan = 0;
    Vector2 lastVelocity, lastPlayerPos;
    public bool firstPlanet = false, isOrbiting = false;
    public static bool orbittest = false;

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

        float dist = Vector2.Distance(transform.position, Player.transform.position);

        float playerTheta = Mathf.Atan2(Player.transform.position.y - lastPlayerPos.y, Player.transform.position.x - lastPlayerPos.x);

        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 velocity = (playerPos - lastPlayerPos) / Time.fixedDeltaTime;

        if (dist <= 4 && PlanetRB.mass > 0.1) {
            //Debug.Log(true);
            Vector2 acceleration = (PlayerRB.velocity - lastVelocity) / Time.fixedDeltaTime;
            
            Orbiting(acceleration, playerTheta, dist);

        }
        else {
            isOrbiting = false;
        }

        

        if (dist <= 5)
        {
            orbRing(playerTheta, velocity);
        }


        Attract(Player);
    
        lastVelocity = PlayerRB.velocity;
        lastPlayerPos = Player.transform.position;
        lastPlayPlanTan = PlayerPlanetTheta();

        
        Debug.Log(Database.isOrbiting);
    }

    void Attract(GameObject objToAttract)
    {
        bool tapped = GetComponent<changeGravity>().firstDoubleTap;
        Vector2 direction = PlanetRB.position - PlayerRB.position;
        float distance = direction.magnitude;

        // Added a repelling force if planet mass is 0
        float planetMass = !tapped ? PlanetRB.mass : zeroRepelForce; // <-- Repel force
        

        // Could add future stuff when planet is at 0 mass here
        if (planetMass < 0) {
            //Debug.Log("Success!");
        }

        // Changed the planetRB.mass to planetMass to incorporate the slight repel force when...
        // ... the mass of the planet is less than 1f
        float forceMagnitude =  ( (planetMass * PlayerRB.mass) / Mathf.Pow(distance, 2));
        Vector2 force = direction.normalized * forceMagnitude;
        orbitVelNum = Mathf.Sqrt(PlanetRB.mass/distance);

        //if the player is far enough away the orbit checking function gets turned off
        if (direction.magnitude > 5)
        {
            firstPlanet = false;
        }
        PlayerRB.AddForce(force);
    }

    Vector2 Orbiting (Vector2 acc, float playTan, float dister) {
       
        Vector2 vel = PlayerRB.velocity;
        
      
        float playPlanTan = PlayerPlanetTheta();
        float angleSum = Mathf.Abs(playTan - playPlanTan) / pi;
        //Debug.Log(angleSum);

        Vector2 direction = PlanetRB.position - PlayerRB.position;

        float forceMagnitude =  ( (PlanetRB.mass * PlayerRB.mass) / Mathf.Pow(dister, 2));
        Vector2 force = direction.normalized * forceMagnitude;

        // Checks to see if the player's angle to the planet around 90 degrees 
        // IMPORTANT: If we want to make the orbit eliptical, it'll be done here
        if((1.4 < angleSum && angleSum < 1.6) || (0.4 < angleSum && angleSum < 0.6)) {

            Vector2 perpForce= new Vector2(0,0);

            float forceX = force.x;
            float forceY = force.y;


            float tanDiff = playPlanTan - lastPlayPlanTan;

            if (tanDiff > 0 && tanDiff < 1) {
                
                perpForce = new Vector2(forceY, -forceX);
                
            }
            else 
            {
                if (tanDiff < -1)
                {
                    perpForce = new Vector2(forceY, -forceX);
                }
                else
                {
                    perpForce = new Vector2(-forceY, forceX);
                }
            }

            Vector2 orbitVel = perpForce.normalized * orbitVelNum;
            Vector2 difference = vel + ((orbitVel - vel) / 15);

            if (orbitVel != vel && Mathf.Abs(orbitVel.magnitude - vel.magnitude) <= 1) {
                isOrbiting = true;
                Player.GetComponent<Rigidbody2D>().velocity = difference;
            }
            else
            {
                isOrbiting = false;
            }
        }

        return PlayerRB.velocity;   
    }

    float PlayerPlanetTheta() {
        // Planet Pos
        float m1X = transform.position.x;
        float m1Y = transform.position.y;

        // Player Pos
        float m2X = Player.transform.position.x;
        float m2Y = Player.transform.position.y;
        
        return Mathf.Atan2(m2Y - m1Y, m2X - m1X);
    }

    void orbRing(float pTheta, Vector2 veloc)
    {
        float pMass = PlanetRB.mass;

        float pVel = veloc.magnitude;

        float ringDist = (pMass / (pVel * pVel));

        OrbitRing.transform.localScale = new Vector3(ringDist, ringDist, 1);
    }
} 


