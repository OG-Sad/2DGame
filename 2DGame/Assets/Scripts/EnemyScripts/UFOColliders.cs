using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOColliders : MonoBehaviour
{
   public static bool PlayerPulled = false;
    GameObject Player, UFO;
    
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

                /*
                Player = GameObject.FindGameObjectWithTag("Player");
                UFO = GameObject.FindGameObjectWithTag("UFO");
                Player.transform.Translate((UFO.transform.position - Player.transform.position).normalized * 5 * Time.deltaTime, Space.World);
                */
            }
        }
    }

  

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Database.gameEnd = true;
        }

        else if (other.gameObject.CompareTag("Planet") | other.gameObject.CompareTag("PowerUp") | other.gameObject.CompareTag("Star"))
        {
            Destroy(gameObject);
            PowerUps.RespawnUFO = true;
        }

    }
}
