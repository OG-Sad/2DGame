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
        if(Database.gameEnd == true)
        {
            Reset();

        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Planet") | other.gameObject.CompareTag("Power")| (other.gameObject.CompareTag("Star")))
        {
            Destroy(transform.parent.gameObject);
            // could put a delay using coroutine
            EnemySpawn.RespawnUFO = true;
        }

        
         if (other.gameObject.CompareTag("Player"))
         {

                UFOColliders.PlayerPulled = true;
         }
         
         if (Database.gameEnd == true)
         {
            Destroy(transform.parent.gameObject);
         }
        
   

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //reset fucks up this stuff
        if (Database.gameEnd == false)
        {


            if (other.gameObject.CompareTag("Player"))
            {

                UFOColliders.PlayerPulled = false;
                float Xspeed = Velocity.PlayerRB.velocity.x;
                Vector2 VectorTest = new Vector2(Xspeed, 4);
                Velocity.PlayerRB.velocity = VectorTest;
            }
        }

      
    }

    void Reset()
    {
        UFOColliders.PlayerPulled = false;
    }

}
