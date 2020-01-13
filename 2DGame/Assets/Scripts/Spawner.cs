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
    private float timer = 0.0f;
    private float timeBetweenSpawn;

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
            timeBetweenSpawn = Random.Range(.5f, 1.5f);
        }

    }

    void SpawnPlanet () {
        if (planets.Count < numberOfPlanets) {
            int odds = Random.Range(0, 4);
            //Debug.Log(odds);
            Transform planet = odds <= 2 ? smallPlanet : bigPlanet;
            Transform t = Instantiate(planet);
            t.localPosition = new Vector2(player.position.x + 20f, Random.Range(-5.5f, 5.5f));
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

}
