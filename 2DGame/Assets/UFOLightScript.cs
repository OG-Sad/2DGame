using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UFOColliders.PlayerPulled = true;
        }

        else if (other.gameObject.CompareTag("Planet") | other.gameObject.CompareTag("PowerUp") | other.gameObject.CompareTag("Star"))
        {
            Destroy(gameObject);
            PowerUps.RespawnUFO = true;
        }



        // if the collider is polygon, then this should happen
        /* else if (other.gameObject.CompareTag("Planet") | other.gameObject.CompareTag("PowerUp") | other.gameObject.CompareTag("Star"))
         {
             Destroy(gameObject);
             PowerUps.RespawnUFO = true;
         }
         */
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            UFOColliders.PlayerPulled = false;
            float Xspeed = Velocity.PlayerRB.velocity.x;
            Vector2 VectorTest = new Vector2(Xspeed, 2);
            Velocity.PlayerRB.velocity = VectorTest;
        }


    }
}
