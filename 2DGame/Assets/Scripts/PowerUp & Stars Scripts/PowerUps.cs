using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Transform InvinciblePowerUp, TimePowerUp, StarPowerUp, BoostPowerUp, Player, Star, UFO;
    public static Transform PowerUp, StarSpawning, UFOSpawning;
    float yPos = 0, timer = 0, seconds = 0, timerForStars;
    public static bool PowerUpTrue = false, PlayerPoweredUp = false, PlayerPotentialPowerUp = false, RespawnUFO = false, IsStarSpawned = false;
    public static int ChoosePowerUp = 0, PowerUpGo = 0, StarGo, UFOGo, ScorePower = 0, ScoreStar = 0;
    public static bool RespawnStar = false;
   


    // Update is called once per frame
    void Update()
    {
        float score = GameObject.Find("Score").GetComponent<ScoreScript>().Score;

        //Every 10 seconds a power up can spawn
        timer += Time.deltaTime;
        timerForStars += Time.deltaTime;
        if (timer >= 10 && ScorePower < score)
        {
            //1/2 times a power up can spawn, it will spawn
            PowerUpGo = Random.Range(0, 2);
            timer = 0;
            ScorePower += 10;
            if (PowerUpGo == 1 && PlayerPotentialPowerUp == false)// && PowerUpTrue == false)
            {
                //EditorApplication.isPaused = true;
                SpawnPowerUp();
            }
        }
        //Every 20 seconds a Star can spawn
        
        if (timerForStars >= 20 && score > ScoreStar)
        {
            
            //1/5 times chance a Star can spawn
            StarGo = Random.Range(0, 4);
            UFOGo = Random.Range(0, 2);
            timerForStars = 0;
            ScoreStar += 5;
            if (StarGo == 1 && IsStarSpawned == false)
            {
                //EditorApplication.isPaused = true;
                SpawnStar();
            }
            //UFO spawns 1/3 times every twenty seconds
            if(UFOGo == 1)
            {
                UFOGo = 0;
                SpawnUFO();
            }

            timerForStars = 0;
        }

        // If the player has the star power up they can tap twice and get powered up
        if (PlayerPotentialPowerUp == true && (Input.touchCount > 1 | Input.GetMouseButtonDown(1)))
        {
            PlayerPoweredUp = true;
            
        }
        // If  the player is powered up, effect of the powerups is called
        if (PlayerPoweredUp == true)
        {

            DuringPowerUp();

        }
        // If the star spawned touching a planet or in one
        if (RespawnStar)
        {
            RespawnStar = false;
            SpawnStar();
        }
        // If the UFO spawned touching a planet or in one
        if (RespawnUFO == true)
        {
            RespawnUFO = false;
            SpawnUFO();
            
        }
    }

    void SpawnPowerUp()
    {
        //makes sure only one power up can spawn at a time
        //chooses which power up should spawn randomly
        ChoosePowerUp = Random.Range(0, 4);
        //Power Up Spawned with random y position or not depending on ypos
        if (ChoosePowerUp == 1)
        {
            PowerUp = Instantiate(InvinciblePowerUp);
            //yPos = Random.Range(-4.5f, 4.5f);
            yPos = 0;
            PowerUp.localPosition = new Vector2(Player.position.x + 20f, yPos);
        }
        if (ChoosePowerUp == 2)
        {
            //yPos = Random.Range(-4.5f, 4.5f);
            yPos = 0;
            PowerUp = Instantiate(TimePowerUp);
            PowerUp.localPosition = new Vector2(Player.position.x + 20f, yPos);
        }
        if(ChoosePowerUp == 3)
        {
            //yPos = Random.Range(-4.5f, 4.5f);
            yPos = 0;
            PowerUp = Instantiate(StarPowerUp);
            PowerUp.localPosition = new Vector2(Player.position.x + 20f, yPos);
        }
        if(ChoosePowerUp == 4)
        {
            yPos = 0;
            PowerUp = Instantiate(BoostPowerUp);
            PowerUp.localPosition = new Vector2(Player.position.x + 20f, yPos);
        }
    }
     void DuringPowerUp()
    {
        //seconds are unscaled because of time power up
        seconds += Time.unscaledDeltaTime;
        // after the power up, the game is restored to before presets
        if (seconds >= 10 && ChoosePowerUp == 1)
        {
            //new power up can spawn
            //player is not powered up
            //seconds reset
            PlayerPoweredUp = false;
            seconds = 0;

        }

        if (seconds >= 6 &&  ChoosePowerUp == 2)
        {
            //new power up can spawn
            // time is set to normal
            //player is not powered up
            //seconds reset
            Time.timeScale = 1f;
            PlayerPoweredUp = false;
            seconds = 0;
            
            
        }
        
        if (seconds >= 6 && ChoosePowerUp == 3)
        {
            //new power up can spawn
            //player is not powered up
            //seconds reset
            PlayerPoweredUp = false;
            seconds = 0;

        }

        if (seconds >= 2 && ChoosePowerUp == 4)
        {
            // finds all the planets and enables the gravity
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enabled = true;
            foreach (GameObject Plan in BoostPoweredUp.Planets)
            {
               Plan.GetComponent<CircleCollider2D>().enabled = true;
            }
            // player not powered up
            // velocity before boost set to the player
            //seconds reset and power up can spawn
            PlayerPoweredUp = false;
            Velocity.speed = BoostPoweredUp.OldSpeed;
            seconds = 0;
            

        }
    }

     void SpawnStar()
    {
        IsStarSpawned = true;
        // puts the star on screen
        var yPoss = 0;
        StarSpawning = Instantiate(Star);
        //yPos = Random.Range(-4.5f, 4.5f);
        StarSpawning.localPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 20f, yPoss);

    }
    public void SpawnUFO()
    {
        // puts the ufo on screen
        float UFOCor = 0;
        //EditorApplication.isPaused = true;
        UFOSpawning = Instantiate(UFO);
        UFOCor = Random.Range(0, 4.5f);
        UFOSpawning.localPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 20f, UFOCor);
        RespawnUFO = false;
    }
}

