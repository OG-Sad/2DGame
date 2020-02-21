using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planetCollision : MonoBehaviour
{
    public Transform planet;
    public bool restartOnCollision;
    void OnCollisionEnter2D(Collision2D coll) {


        if (coll.gameObject.tag == "Player" && PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 1)
        {

            GameObject.FindGameObjectWithTag("Planet").GetComponent<Attractor>().enabled = false;

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

            else if (coll.gameObject.tag == "Player" && restartOnCollision)
            {

                // Debug.Log("Testing: We're in...");
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
            // Debug.Log("Collision");
        }
    }
     void OnCollisionExit2D(Collision2D coll)
    {
        GameObject.FindGameObjectWithTag("Planet").GetComponent<Attractor>().enabled = true;
    }
}