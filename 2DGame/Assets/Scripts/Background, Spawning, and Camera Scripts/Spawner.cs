using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform smallPlanet;
    public Transform bigPlanet;
    public Transform player;
    public int numberOfPlanets = 4;
    public float vertDistanceBetweenPlanets = 2.5f;
    public float minXBetweenSpawn = 14f;
    public float maxXBetweenSpawn = 20f;
    public float xConstraint = 18f;
    
    Transform item, item2 = null;
    //private float timer = 0.0f;
    private float timeBetweenSpawn, lastYPos, yPos;
    private bool firstSpawn;
    
    List<Transform> planets;


    void Awake () {
        planets = new List<Transform>();
        yPos = Random.Range(0, 10) < 5 ? Random.Range(3, 4.5f) : Random.Range(-3, -4.5f);
        lastYPos = yPos;
        SpawnPlanet(yPos);
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < planets.Count; i++) {
            if(planets[i].localPosition.x < player.position.x - 10f) {
                item = planets[i];
                planets.Remove(item);
                Destroy(item.gameObject);
                //Debug.Log("Removed");                
            }
        }

        if (planets[planets.Count-1].localPosition.x < player.position.x + xConstraint && firstSpawn == false && planets.Count < numberOfPlanets) {
            yPos = BetterSpawning(lastYPos, yPos);
            lastYPos = yPos;

            SpawnPlanet(yPos); 

            xConstraint = Random.Range(minXBetweenSpawn, maxXBetweenSpawn);
        }
    }

    void SpawnPlanet (float yPos) {     
        firstSpawn = false;
        //timer = 0;
        int odds = Random.Range(0, 4);
        Transform planet = odds <= 2 ? smallPlanet : bigPlanet;
        Transform t = Instantiate(planet);
        t.localPosition = new Vector2(player.position.x + 25f, yPos);
        planets.Add(t);   
    }

    public void PlanetCollision () {
        item2 = planets[planets.Count-1];
        planets.Remove(item2);
        Destroy(item2.gameObject);
        BetterSpawning(lastYPos, yPos);
        //timer = 0.0f;
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
        BetterSpawning(lastYPos, yPos);
    }

    // Note for future Karsten:
    // Change the 'Y' Pos of the next planet to spawn here
    public float BetterSpawning(float lastYPosition, float yPosition) {
    
        while (Mathf.Abs( Mathf.Abs(lastYPosition + 4.5f) - Mathf.Abs(yPosition + 4.5f) ) < vertDistanceBetweenPlanets || firstSpawn == true) {
                
            
            yPosition = Random.Range(-4.5f, 4.5f);

        }

        return yPosition;
    }

}
