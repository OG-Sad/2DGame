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
        if (other.gameObject.name == "Player" && PowerUps.ChoosePowerUp == 1) { 
            PowerUps.PlayerPoweredUp = true;
            Destroy(gameObject);
            
        }

        if (other.gameObject.name == "Player" && PowerUps.ChoosePowerUp == 2)
        {
            PowerUps.PlayerPoweredUp = true;
            Destroy(gameObject);
            Time.timeScale = 0f;
        }

        if (other.gameObject.name == "Player" && PowerUps.ChoosePowerUp == 3)
        {
            PowerUps.PlayerPotentialPowerUp = true;
            Destroy(gameObject);

        }
        if (other.gameObject.name == "Player" && PowerUps.ChoosePowerUp == 4)
        {
            PowerUps.PlayerPoweredUp = true;
            Destroy(gameObject);
        }

    }
}
