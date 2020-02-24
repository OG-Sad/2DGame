using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public Transform Star;
    public static Transform StarSpawning;
    GameObject[] currentStars;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 10f)
        {
            Destroy(gameObject);
        }

        if (PowerUps.ChoosePowerUp == 3 && PowerUps.PlayerPoweredUp == true)
        {
            GameObject P = GameObject.FindGameObjectWithTag("Player");
            currentStars = GameObject.FindGameObjectsWithTag("Star");
            foreach (GameObject GameObjStar in currentStars)
            {

                if (Vector3.Distance(GameObjStar.transform.position, P.transform.position) < 10)
                {

                    GameObjStar.transform.Translate((P.transform.position - GameObjStar.transform.position).normalized * 5 * Time.deltaTime, Space.World);

                }
            }
            
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("Star Col");
            if (other.gameObject.name == "Player")
            {
                //adds 1 star to the current number of stars
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
                Destroy(gameObject);

            }
            if (other.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            PowerUps.RespawnStar = true;
        }

    }

    
}
