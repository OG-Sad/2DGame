
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//maybe have to use tags that 
public class PlanetSpawning : MonoBehaviour
{
    public GameObject spawnObj, Assest;
    public Transform Player;
    public float MinY = -4;
    public float MaxY = 4;
    public static int planetCounter = 0;
    bool trueSpawn = true;

    public static List<GameObject> Planets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var RandomSpawnNum = (Random.Range(0, 80));
        var RandomPlanetCount = (Random.Range(0, 10));

        if (Planets.Count <= RandomPlanetCount && RandomSpawnNum == 0)
        {
            SpawnPlanets();

        }


        for (int i = 0; i <= Planets.Count; i++)
        {
            if (Planets[i] != null)
            {
                if (Planets[i].transform.position.x <= Player.position.x - 5)
                {
                    Destroy(Planets[i]);
                    Planets.RemoveAt(i);
                    PlanetSpawning.planetCounter--;
                    break;
                }
            }
        }


    }

    void Respawn()
    {

        GameObject RespawnPlanets = Planets[Planets.Count - 1];
        Destroy(RespawnPlanets);
        Planets.Remove(RespawnPlanets);
        PlanetSpawning.planetCounter--;

    }
    void SpawnPlanets()
    {

        var RandomPlanetSize = (Random.Range(0, 5));
        if (RandomPlanetSize >= 1 && RandomPlanetSize <= 5)
        {
             Assest = Resources.Load("Planet") as GameObject;
           
        }
        if (RandomPlanetSize == 0)
        {
             Assest = Resources.Load("BigPlanet") as GameObject;
           
        }
    
        float yPos = Random.Range(MinY, MaxY);
        var test = Instantiate(Assest, new Vector3(Player.position.x + 15f, yPos, 0), Quaternion.identity);
        Planets.Add(test);
        PlanetSpawning.planetCounter++;
        




    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.name == "Player")
        {
            Debug.Log("Game Over");
            EditorApplication.isPaused = true;

        }
        else if (col.gameObject.tag == "PlanetTag" && trueSpawn)
        {
            trueSpawn = !trueSpawn;
            Respawn();

        }

    }

}    

