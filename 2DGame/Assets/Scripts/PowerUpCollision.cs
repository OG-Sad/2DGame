using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    //private static GameObject myPrefabInstances;
    //public Transform player;

    //public Renderer rend;
    void Update ()
    {
        if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Col");
        if (other.gameObject.name == "Player") { 
            PowerUps.PlayerPoweredUp = true;
            Destroy(gameObject);
            
        }
    }
}
