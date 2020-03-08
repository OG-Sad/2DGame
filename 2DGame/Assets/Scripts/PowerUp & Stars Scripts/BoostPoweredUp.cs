using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPoweredUp : MonoBehaviour
{
    public static float OldSpeed;
    public static GameObject[] Planets, Meteors, UFOs;
    public Transform  Meteor, UFO;
    bool OneTime = true;
    
   
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //find all planets
        Planets = GameObject.FindGameObjectsWithTag("Planet");
        Meteors = GameObject.FindGameObjectsWithTag("Meteor");
        UFOs = GameObject.FindGameObjectsWithTag("UFO");
        // if the boost power up is true and the player is powered up
        if (PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 4 && OneTime == true)
        {
            Debug.Log("Powered up");
            // turn gravity off on all planets and spawning
            foreach (GameObject Plan in Planets)
            {
                Plan.GetComponent<CircleCollider2D>().enabled = false;
            }

            Meteor.GetComponent<CircleCollider2D>().enabled = false;
            UFO.GetComponent<PolygonCollider2D>().enabled = false;
            UFO.GetComponentInChildren<PolygonCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enabled = false;
            //store old velocity
            OldSpeed = Velocity.speed;
            //change max speed for boost
            Velocity.MaxSpeed = 30f;
            //add big boost in the x direction
            Velocity.forceVector = new Vector2(200, 0);
            Velocity.PlayerRB.AddForce(Velocity.forceVector);
            OneTime = false;
           

        }
        else
        {
            OneTime = true;
        }
        //reset game
        if(Database.gameEnd == true)
        {
            Velocity.speed = 0;
            Velocity.forceVector = new Vector2(-200, 0);
            Velocity.PlayerRB.AddForce(Velocity.forceVector);
            Velocity.forceVector = new Vector2(0, 300);
            Velocity.PlayerRB.AddForce(Velocity.forceVector);
            Debug.Log("game is ended");
        }
       // if (PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 1)
        //{
            // turn kill off
            //PlanetPrefabs.GetComponent<CircleCollider2D>().enabled = false;
                       
        //}
        
    }
}
