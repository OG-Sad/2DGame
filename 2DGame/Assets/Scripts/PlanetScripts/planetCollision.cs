using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planetCollision : MonoBehaviour
{
    
    public Transform planet;

    void OnCollisionEnter2D(Collision2D coll) {

        // if the player collides with a planet and has invicible power up they don't die
        if (coll.gameObject.tag == "Player" && PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 1)
        {
            
           // GameObject.FindGameObjectWithTag("Planet").GetComponent<Attractor>().enabled = false;

        }

        else
        {
            if (coll.gameObject.tag == "Planet")
            {
                // Debug.Log("We're in...");
                FindObjectOfType<Spawner>().PlanetCollision();
            }
            if (coll.gameObject.tag == "Player" && FindObjectOfType<Velocity>().testing == true)
            {
                // Debug.Log("Testing: We're in...");
                FindObjectOfType<Spawner>().DestroyPlanet(planet);
            }
        }
    }
     void OnCollisionExit2D(Collision2D coll)
    {
       // GameObject.FindGameObjectWithTag("Planet").GetComponent<Attractor>().enabled = true;
    }
}