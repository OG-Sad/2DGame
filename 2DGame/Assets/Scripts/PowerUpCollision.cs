using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    //private static GameObject myPrefabInstances;

    //public Renderer rend;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Col");
        if (other.gameObject.name == "Player") { 
            PowerUps.PlayerPoweredUp = true;
            Destroy(gameObject);
            
        }
    }
}
