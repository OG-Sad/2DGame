using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
   
    void Update()
    {
        if(Database.gameEnd == false)
        {
            // if any of the power ups are too far behind the player, destroy them
            if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 10f)
            {
                Destroy(gameObject);
            }

        }

        
       
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Fire.startColor = new Color(0, 0, 255, 1f);


        //Fire.startColor = TrailColorP;
        //Fire.GetComponent<Color>();
        //Fire.startColor = Color.blue;
        // Fire.GetComponent<Material>();
        // power up the player on collision or potential and destroy the power up, 
        if (other.gameObject.name == "Player" && PowerUps.ChoosePowerUp == 1)
        {
            PowerUps.PlayerPoweredUp = true;
            Destroy(gameObject);
            

        }

        if (other.gameObject.name == "Player" && PowerUps.ChoosePowerUp == 2)
            {
                PowerUps.PlayerPoweredUp = true;
                Destroy(gameObject);
                // set the time stop power up
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
