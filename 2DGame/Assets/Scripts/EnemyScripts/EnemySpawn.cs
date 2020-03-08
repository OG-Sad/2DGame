using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static int UFOGo = 0;
    public static bool RespawnUFO = false;
    public Transform UFO;
    public static Transform UFOSpawning;
    float UFOTime = 0, EnemyScoreSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UFOTime += Time.deltaTime;
        float score = GameObject.Find("Score").GetComponent<ScoreScript>().Score;
        if (UFOTime >= 10 && score > EnemyScoreSpawn)
        {

            //1/5 times chance a Star can spawn

            UFOGo = Random.Range(0, 2);
            EnemyScoreSpawn += 10;

            //UFO spawns 1/3 times every twenty seconds
            if (UFOGo == 1)
            {
                UFOGo = 0;
                SpawnUFO();
            }

            UFOTime = 0;
        }

        if (RespawnUFO == true)
        {
            UFOTime = 0;
            RespawnUFO = false;
            SpawnUFO();

        }

    }

    public void SpawnUFO()
    {
        // puts the ufo on screen
        
        //EditorApplication.isPaused = true;
        UFOSpawning = Instantiate(UFO);
        float UFOCor = Random.Range(0, 4.5f);
        UFOSpawning.localPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 20f, UFOCor);
        RespawnUFO = false;
    }
}
