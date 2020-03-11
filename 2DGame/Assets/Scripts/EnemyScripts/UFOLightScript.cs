using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLightScript : MonoBehaviour
{
    float timer;
    Collider2D UFOlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.unscaledDeltaTime;
        if (Database.gameEnd == true)
        {
            Reset();

        }
        if (UFOColliders.PlayerPulled == true)
        {
            Debug.Log("player pulled");

        }

        if(timer >= 1)
        {
            UFOlight = GetComponent<PolygonCollider2D>();
            //Here the GameObject's Collider is not a trigger
            UFOlight.isTrigger = true;
            timer = 0;
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

        if (Database.gameEnd == true)
        {
            UFOColliders.PlayerPulled = false;

        }



    }

    void Reset()
    {
        UFOColliders.PlayerPulled = false;
    }

}
