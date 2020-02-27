using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPoweredUp : MonoBehaviour
{
    public static float OldSpeed;
    public static GameObject[] Planets;
    public Transform  PlanetPrefabs;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //find all planets
        Planets = GameObject.FindGameObjectsWithTag("Planet");
        // if the boost power up is true and the player is powered up
        if (PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 4)
        {
            // turn gravity off on all planets and spawning
            PlanetPrefabs.GetComponent < CircleCollider2D >().enabled = false;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enabled = false;
            //store old velocity
            OldSpeed = Velocity.speed;
            //change max speed for boost
            Velocity.MaxSpeed = 30f;
            //add big boost in the x direction
            Velocity.forceVector = new Vector2(500, 0);
            Velocity.PlayerRB.AddForce(Velocity.forceVector);
           

        }
       // if (PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 1)
        //{
            // turn kill off
            //PlanetPrefabs.GetComponent<CircleCollider2D>().enabled = false;
                       
        //}
        
    }
}
