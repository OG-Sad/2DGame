using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public Transform UFO;
    public static Transform UFOSpawning;
    public static bool RespawnUFO = false;
    public static int UFOGo = 0;
    float UFOTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UFOTimer += Time.deltaTime;
        //every ten seconds  a ufo can spawn
        if(UFOTimer >= 5)
        {
            // 1/2 chance the ufo spawns
            UFOGo = Random.Range(0, 2);
            if(UFOGo == 1)
            {
                Debug.Log("UFO spawn is the  problem");
                SpawnUFO();
            }
            UFOTimer = 0;
        }
        //if the ufo spawned touching something, respawn it
        if (RespawnUFO == true)
        {
            Debug.Log("UFO respawn is the  problem");
            SpawnUFO();
            RespawnUFO = false;
        }

    }

    public void SpawnUFO()
    {
        // puts the ufo on screen
        float UFOCor = 0;
        //EditorApplication.isPaused = true;
        UFOSpawning = Instantiate(UFO);
        UFOCor = Random.Range(0, 4.5f);
        UFOSpawning.localPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 20f, UFOCor);
        
    }
}
