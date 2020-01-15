using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform smallPlanet;
    public Transform bigPlanet;
    public Transform player;
    List<Transform> planets;

    Transform item, item2 = null;
    public int numberOfPlanets = 4;
    public float distanceBetweenPlanets = 2.5f;
    private float timer = 0.0f;
    private float timeBetweenSpawn, lastYPos;
    private bool firstSpawn;
    public float minTimeBetweenSpawn = .5f;
    public float maxTimeBetweenSpawn = 2.5f;


    planetCollision world;


    void Awake () {
        planets = new List<Transform>();
    }

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i < planets.Count; i++) {
            if(planets[i].localPosition.x < player.position.x - 20f) {
                item = planets[i];
                planets.Remove(item);
                Destroy(item.gameObject);
                //Debug.Log("Removed");                
            }
        }

        timer += Time.deltaTime;
        if (timer >= timeBetweenSpawn) {
            SpawnPlanet();
            timer = 0;
            timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        }

    }

    void SpawnPlanet () {
        if (planets.Count < numberOfPlanets) {
            float yPos = Random.Range(-4.5f, 4.5f);
            while (Mathf.Abs(Mathf.Abs(lastYPos + 4.5f) - Mathf.Abs(yPos + 4.5f)) < distanceBetweenPlanets || firstSpawn == true) {
                yPos = Random.Range(-4.5f, 4.5f);
            }
            //Debug.Log("Difference of last two Y Positions: " + Mathf.Abs(Mathf.Abs(lastYPos + 4.5f) - Mathf.Abs(yPos + 4.5f)));
            lastYPos = yPos;
            firstSpawn = false;
            int odds = Random.Range(0, 4);
            //Debug.Log(odds);
            //Debug.Log("Y Position of planet: " + yPos);
            Transform planet = odds <= 2 ? smallPlanet : bigPlanet;
            Transform t = Instantiate(planet);
            t.localPosition = new Vector2(player.position.x + 20f, yPos);
            planets.Add(t);
        }
    }

    public void PlanetCollision () {
        item2 = planets[planets.Count-1];
        planets.Remove(item2);
        Destroy(item2.gameObject);
        SpawnPlanet();
        timer = 0.0f;
    }

    public void DestroyPlanet(Transform colPlanet) {
        int j = 0;
        for (int i = 0; i < planets.Count; i++) {
            if (planets[i] == colPlanet) {
                j = i;
            }    
        }
        item2 = planets[j];
        planets.Remove(item2);
        Destroy(item2.gameObject);
    }

}
