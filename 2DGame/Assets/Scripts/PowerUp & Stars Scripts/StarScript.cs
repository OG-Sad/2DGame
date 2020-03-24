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
        if (other.gameObject.name == "Player")
        {
            CollectStar();
            Destroy(gameObject);
            PowerUps.IsStarSpawned = false;


        }

        if (other.gameObject.CompareTag("Planet"))
        {
            // if the star collides with the planet, then respawn the star
            Destroy(gameObject);
            PowerUps.RespawnStar = true;
        }



    }

    //adds to the star counter depending on if the star powerup is actiavted and what level it is upgraded to
    private void CollectStar() {
        Dictionary<string, ShopItem> itemList = Database.itemList;
        int upgradeLevel = itemList["Star"].upgradeLevel;

        //if the star power up is currently activated
        //whatever changes in here must also change in ShopController.cs
        if (PowerUps.ChoosePowerUp == 3)
        {
            if (upgradeLevel == 1)
            {
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 2);
            }
            else if (upgradeLevel == 2)
            {
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 4);
            }
            else if (upgradeLevel == 3)
            {
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 7);
            }
            else if (upgradeLevel == 4)
            {
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 11);
            }
            else if (upgradeLevel == 5)
            {
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 16);
            }
        }
        else {
            PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
        }
    }

}
