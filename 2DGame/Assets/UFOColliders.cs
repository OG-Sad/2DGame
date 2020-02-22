using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOColliders : MonoBehaviour
{
    bool PlayerPulled = false;
    GameObject Player, UFO;
    
    // Start is called before the first frame update
    void Update()
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPulled = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        PlayerPulled = false;
        float Xspeed = Velocity.PlayerRB.velocity.x;
        Vector2 VectorTest = new Vector2(Xspeed, 2);
        Velocity.PlayerRB.velocity = VectorTest;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Database.planetCollision = true;
        }

        else if (other.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            PowerUps.RespawnUFO = true;
        }

    }
}
