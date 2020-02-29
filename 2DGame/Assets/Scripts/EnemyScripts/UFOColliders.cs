using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOColliders : MonoBehaviour
{
    bool PlayerPulled = false;
   
    // Start is called before the first frame update
    void Update()
    {
        if (Database.gameEnd == false)
        {
            if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 10f)
            {
                Destroy(gameObject);
                
            }
            if (PlayerPulled == true)
            {

                Vector2 Vector = new Vector2(0, 18);
                Velocity.PlayerRB.AddForce(Vector);
                Debug.Log(Velocity.PlayerRB);

                /*
                Player = GameObject.FindGameObjectWithTag("Player");
                UFO = GameObject.FindGameObjectWithTag("UFO");
                Player.transform.Translate((UFO.transform.position - Player.transform.position).normalized * 5 * Time.deltaTime, Space.World);
                */
            }

            if (PowerUps.PlayerPoweredUp = true && PowerUps.ChoosePowerUp == 4)
            {
                Destroy(gameObject);
               
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPulled = true;
        }

        if (other.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);
            EnemySpawning.RespawnUFO = true;
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPulled = false;
            float Xspeed = Velocity.PlayerRB.velocity.x;
            Vector2 VectorTest = new Vector2(Xspeed, 2);
            Velocity.PlayerRB.velocity = VectorTest;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Database.gameEnd = true;
        }

        else if (other.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);
            EnemySpawning.RespawnUFO = true;
        }

    }
}
