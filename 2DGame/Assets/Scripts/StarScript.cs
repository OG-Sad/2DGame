using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public Transform Star;
    public static Transform StarSpawning;
    GameObject[] currentStars;
    float yPos = 0, timer = 0;
    public static int StarGo, GameStarCounter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Every 20 seconds a Star can spawn
        timer += Time.deltaTime;
        if (timer >= 20)
        {
            //1/5 times chance a Star can spawn
            StarGo = Random.Range(0, 5);
            timer = 0;

            if (StarGo == 4)
            {
                //EditorApplication.isPaused = true;
                SpawnStar();
            }
        }

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
    void SpawnStar()
    {

            //EditorApplication.isPaused = true;
            StarSpawning = Instantiate(Star);
            //yPos = Random.Range(-4.5f, 4.5f);
            yPos = 0;
            StarSpawning.localPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 20f, yPos);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("Star Col");
            if (other.gameObject.name == "Player")
            {
                GameStarCounter++;
                Destroy(gameObject);

            }

    }

    
}
