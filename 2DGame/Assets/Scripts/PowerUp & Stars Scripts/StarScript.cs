using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public Transform Star;
    public static Transform StarSpawning;
    GameObject[] currentStars;

   
    // Update is called once per frame
    void Update()
    {
        if (Database.gameEnd == false)
        {
            // if the star is too far behind the player, destroy it
            if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 10f)
            {
                PowerUps.IsStarSpawned = false;
                Destroy(gameObject);
            }
            // if the star magnent is powered up, makes the star attract to the player
            if (PowerUps.ChoosePowerUp == 3 && PowerUps.PlayerPoweredUp == true)
            {
                // finds the player and any stars on screen 
                GameObject P = GameObject.FindGameObjectWithTag("Player");
                currentStars = GameObject.FindGameObjectsWithTag("Star");
                foreach (GameObject GameObjStar in currentStars)
                {
                    // if any of the stars is less than ten away, move them towards the player
                    if (Vector3.Distance(GameObjStar.transform.position, P.transform.position) < 10)
                    {

                        GameObjStar.transform.Translate((P.transform.position - GameObjStar.transform.position).normalized * 5 * Time.deltaTime, Space.World);

                    }
                }


            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
            // if the star collides with the player
            if (other.gameObject.name == "Player")
            {
                //adds 1 star to the current number of stars and destroys the star
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
                Destroy(gameObject);
                PowerUps.IsStarSpawned = false;


        }
        if (other.gameObject.tag == "Planet")
        {
            // if the star collides with the planet, then respawn the star
            Destroy(gameObject);
            PowerUps.RespawnStar = true;
        }

    }

    
}
