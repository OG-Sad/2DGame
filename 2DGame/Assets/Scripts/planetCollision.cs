using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Planet") {
            // Debug.Log("We're in...");
            FindObjectOfType<Spawner>().PlanetCollision();
        }
        // Debug.Log("Collision");
    }
}
