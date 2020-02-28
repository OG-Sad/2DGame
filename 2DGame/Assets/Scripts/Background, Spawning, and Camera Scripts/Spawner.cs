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
    
    Transform item, item2 = null;
    //private float timer = 0.0f;
    private float lastYPos, yPos, timer, minXBetweenSpawn = 14, maxXBetweenSpawn = 17,  xConstraint = 15;
    private bool firstSpawn = true, scored;
    private Vector2 prePosition;
    
    List<Transform> planets;


    void Awake () {
        planets = new List<Transform>();

        timer = 0;

        yPos = Random.Range(0, 10) < 5 ? Random.Range(3, 4.5f) : Random.Range(-3, -4.5f);
        lastYPos = yPos;
        SpawnPlanet(yPos);
    }

    // Update is called once per frame
    void Update () {
        
        //bool angleTest = false;

        // When Score is greater than 75, scored changes to true;
        float score = GameObject.Find("Score").GetComponent<ScoreScript>().Score;
        scored = GameObject.Find("Score").GetComponent<ScoreScript>().Score > 75 ? true : false;

        // Decreases x distance between planets as score increases
        minXBetweenSpawn = minXBetweenSpawn >= 17 ? 17 : minXBetweenSpawn + (score / 50);
        maxXBetweenSpawn = maxXBetweenSpawn >= 20 ? 20 : maxXBetweenSpawn + (score / 50);

        timer += Time.deltaTime;

        if(timer >= 0.2f) {
            timer = 0;
            prePosition = new Vector2(player.localPosition.x, player.localPosition.y);
        }

        for (int i = 0; i < planets.Count; i++) {

            // If the planet is '-x' behind the player, the planet gets removed
            if(planets[i].localPosition.x < player.position.x - 15f) {
                item = planets[i];
                planets.Remove(item);
                Destroy(item.gameObject);
                //Debug.Log("Removed");                
            }


            // If player is moving towards a planet because there is a planet behind that one, pulling the player...
            // ... towards it, then this will check to see if that is happening. If true, then this will move the...
            // ... planet up or down off-screen, to avoid having the player loose for something that isn't their fault.
            if(( planets[i].localPosition.x > player.position.x ) && ( i < numberOfPlanets - 1 ) && ( timer >= 0.175f )) {

                // Difference from player to planet[i] and then finds the Tan inverse of planetOneDiff
                Vector2 planetOneDiff = DifferenceCalculator(planets[i].localPosition, player.localPosition);
                float PlanetTan1 = Mathf.Atan(planetOneDiff.y / planetOneDiff.x);

                for(int j = i + 1; j < planets.Count; j++) {

                    // Difference from planet[i] to planet[j]
                    Vector2 planetTwoDiff = DifferenceCalculator(planetOneDiff, planets[j].localPosition);
                    // Difference from player's previous position to player's current position
                    Vector2 playerVPlayerDiff = DifferenceCalculator(prePosition, player.localPosition);
                    
                    // Finds the Tan inverse of the planetTwoDiff and playerVPlayerDiff
                    float PlanetTan2 = Mathf.Atan(planetTwoDiff.y / planetTwoDiff.x);
                    float playerTan = Mathf.Atan(playerVPlayerDiff.y / playerVPlayerDiff.x);

                    // Checks to see if PlanetTan1 falls in a range of +/- 'n' amount from playerTan, does the same thing again,...
                    // ... but this time comparing PlanetTan1 with a range around PlanetTan2. If true, change the position of...
                    // ... planets[j].
                    if (PlanetTan1 < playerTan + 0.05f && PlanetTan1 > playerTan - 0.05f && planets[j].localPosition.x > player.position.x + 15) {
                        if (PlanetTan1 < PlanetTan2 + 0.03f && PlanetTan1 > PlanetTan2 - 0.03f) {
                            
                            Debug.Log("P1 Tan: " + PlanetTan1);
                            Debug.Log("P2 Tan: " + PlanetTan2);
                            Debug.Log("Player Tan: " + playerTan);
                            //Time.timeScale = 0;
                            
                            float newYDisplace = planets[j].localPosition.y + 4.5f > 4.5f ? -4f : 4f;
                            planets[j].position += new Vector3(0, newYDisplace, 0);
                        }
                    }
                }
            }
        }
        
        // If last planet spawned is less than a randomly generated amount in front of the player, and the number of planets is...
        // ... less than the number specified by 'numberOfPlanets', runs the functions to spawn another planet.
        if (planets[planets.Count-1].localPosition.x < player.position.x + xConstraint && firstSpawn == false && planets.Count < numberOfPlanets) {
            yPos = BetterSpawning(lastYPos, yPos);
            lastYPos = yPos;

            SpawnPlanet(yPos); 

            xConstraint = Random.Range(minXBetweenSpawn, maxXBetweenSpawn);
        }
    }

    void SpawnPlanet (float yPos) {  

        float playerPosPlus = firstSpawn ? 15 : 25;

        firstSpawn = false;
        // Doesn't spawn big planets until score reaches 75
        int odds = scored ? Random.Range(0, 4) : 0;
        Transform planet = odds <= 2 ? smallPlanet : bigPlanet;
        Transform t = Instantiate(planet);
        // Debug.Log(playerPosPlus);
        t.localPosition = new Vector2(player.position.x + playerPosPlus, yPos);
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

    // Literally what it says
    public Vector2 DifferenceCalculator (Vector2 firstObj, Vector2 secondObj) {
        Vector2 diff = new Vector2(firstObj.x - secondObj.x, (secondObj.y + 4.5f) - (firstObj.y + 4.5f));
        return diff;
    }

}