using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetCollision : MonoBehaviour
{
    public Transform planet;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Planet") {
            // Debug.Log("We're in...");
            FindObjectOfType<Spawner>().PlanetCollision();
        }
        if (coll.gameObject.tag == "Player" && FindObjectOfType<Velocity>().testing == true) {
            // Debug.Log("Testing: We're in...");
            FindObjectOfType<Spawner>().DestroyPlanet(planet);
        }
        // Debug.Log("Collision");
    }
}