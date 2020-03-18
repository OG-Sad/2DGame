using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Transform InvinciblePowerUp, TimePowerUp, StarPowerUp, BoostPowerUp, Player, Star;
    public static Transform PowerUp, StarSpawning;
    float yPos = 0, timer = 0, seconds = 0, timerForStars;
    public static bool PowerUpTrue = false, PlayerPoweredUp = false, PlayerPotentialPowerUp = false, IsStarSpawned = false, RespawnPower = false;
    public static int ChoosePowerUp = 0, PowerUpGo = 0, StarGo, ScorePower = 0, ScoreStar = 0;
    public static bool RespawnStar = false;
    // the different materials of trail colors
    public Material GreenTrail, BlueTrail, PurpleTrail, GreyTrail;
    // for changing the trails color
    public TrailRenderer Trail;
    Material OriginTrial;
    int secs;
    float faster = 1.5f , fast = 0;

    void Start()
    {
        //Trail.material = Trail.materials[0];
       OriginTrial = Trail.material;
    }
    // Update is called once per frame
    void Update()
    {
        
        float score = GameObject.Find("Score").GetComponent<ScoreScript>().Score;

        //Every 10 seconds a power up can spawn
        timer += Time.deltaTime;
        timerForStars += Time.deltaTime;
        if (timer >= 10 && ScorePower < score && PlayerPoweredUp == false && PlayerPotentialPowerUp == false)
        {
            //1/2 times a power up can spawn, it will spawn
            PowerUpGo = Random.Range(0, 2);
            timer = 0;
            ScorePower += 25;
            if (PowerUpGo == 1 && !PlayerPotentialPowerUp && !PlayerPoweredUp)// && PowerUpTrue == false)
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
            timerForStars = 0;
            
            if (StarGo == 1 && IsStarSpawned == false)
            {
                ScoreStar += 75;
                StarGo = 0;
                //EditorApplication.isPaused = true;
                SpawnStar();
            }
            

            timerForStars = 0;
        }

        // If the player has the star power up they can tap twice and get powered up
        if (PlayerPotentialPowerUp == true && Input.touchCount > 0)
        {
            PlayerPotentialPowerUp = false;
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

        // If the powerup spawned touching a planet or in one
        if (RespawnPower)
        {
            RespawnPower = false;
            SpawnPowerUp();
        }

    }

    void SpawnPowerUp()
    {
        //makes sure only one power up can spawn at a time
        //chooses which power up should spawn randomly
        ChoosePowerUp = Random.Range(1, 5);
        //ChoosePowerUp = 4;
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
        //var v = Trail.material;
        if (ChoosePowerUp == 1)
        {
            Trail.material = GreenTrail;
            
            //Trail.material = Trail.materials[3];
            //Trail.colorGradient =
            
        }

        if(ChoosePowerUp == 2)
        {
            Trail.material = BlueTrail;
            //Trail.material = Trail.materials[3];

        }

        if (ChoosePowerUp == 3)
        {
            Trail.material = PurpleTrail;

            //Trail.material = Trail.materials[3];

        }

        if (ChoosePowerUp == 4)
        {
            Trail.material = GreyTrail;

            //Trail.material = Trail.materials[3];

        }

       

        //seconds are unscaled because of time power up
        seconds += Time.unscaledDeltaTime;
       
         //secs = (int)(seconds);
        
        if (ChoosePowerUp == 1 && seconds >= 8 && seconds <= 10)
        {
            if (secs % 2 == 0)
            {
                Trail.emitting = false;
                //Trail.GetComponent<TrailRenderer>().enabled = false;
                //secs = (int)(seconds);
                secs = (int)(seconds + faster);
                faster += .1f;
                fast += .001f;
                faster += fast;
                
            }

            else if (secs % 2 != 0)
            {
                //Debug.Log("out");
                Trail.emitting = true;
                //Trail.GetComponent<TrailRenderer>().enabled = true;
               // secs = (int)(seconds);
                secs = (int)(seconds + faster);
                faster += .1f;
                fast += .001f;
                faster += fast;
            }
        }

        if ((ChoosePowerUp == 2 | ChoosePowerUp == 3) && seconds >= 3 && seconds <= 6)
        {
            if (secs % 2 == 0)
            {
                Trail.emitting = false;
                //Trail.GetComponent<TrailRenderer>().enabled = false;
                //secs = (int)(seconds);
                secs = (int)(seconds + faster);
                faster += .1f;
                fast += .001f;
                faster += fast;



            }

            else if (secs % 2 != 0)
            {
                //Debug.Log("out");
                Trail.emitting = true;
                //Trail.GetComponent<TrailRenderer>().enabled = true;
                // secs = (int)(seconds);
                secs = (int)(seconds + faster);
                faster += .1f;
                fast += .001f;
                faster += fast;
            }
        }

        // after the power up, the game is restored to before presets
       
        if (seconds >= GetPowerUpDuration(1) && ChoosePowerUp == 1)
        {
            Trail.emitting = true;
            //new power up can spawn
            //player is not powered up
            //seconds reset
            PlayerPoweredUp = false;
            seconds = 0;
            // Trail.material = Trail.materials[0];
            Trail.material = OriginTrial;
            //Trail.colorGradient = v;
            //Trail.startColor = default;



        }

        if (seconds >= GetPowerUpDuration(2) &&  ChoosePowerUp == 2)
        {
            Trail.enabled = true;
            //new power up can spawn
            // time is set to normal
            //player is not powered up
            //seconds reset
            Time.timeScale = 1f;
            PlayerPoweredUp = false;
            seconds = 0;
            Trail.material = OriginTrial;
            //Trail.material = Trail.materials[0];
            //Trail.colorGradient = v;




        }

        if (seconds >= GetPowerUpDuration(3) && ChoosePowerUp == 3)
        {
            Trail.emitting = true;
            //new power up can spawn
            //player is not powered up
            //seconds reset
            PlayerPoweredUp = false;
            seconds = 0;
            Trail.material = OriginTrial;
            // Trail.material = Trail.materials[0];
            //Trail.colorGradient = v;



        }

        if (seconds >= GetPowerUpDuration(4) && ChoosePowerUp == 4)
        {
            Trail.emitting = true;
            // finds all the planets and enables the gravity
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enabled = true;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawn>().enabled = true;

            foreach (GameObject Plan in BoostPoweredUp.Planets)
             {
               Plan.GetComponent<CircleCollider2D>().enabled = true;
             }

            foreach (GameObject Met in BoostPoweredUp.Meteors)
            {
                Met.GetComponent<CircleCollider2D>().enabled = true;
            }

            foreach (GameObject UFO in BoostPoweredUp.UFOs)
            {

               UFO.GetComponent<PolygonCollider2D>().enabled = true;
               UFO.GetComponentInChildren<PolygonCollider2D>().enabled = true;
            }

            // player not powered up
            // velocity before boost set to the player
            //seconds reset and power up can spawn
            PlayerPoweredUp = false;
            Velocity.speed = BoostPoweredUp.OldSpeed;
            seconds = 0;
            Trail.material = OriginTrial;
           
        }

      
    }

    //gets the time duration of an activated power up
    private int GetPowerUpDuration(int powerUpNumber) {
        Dictionary<string, ShopItem> itemList = Database.itemList;

        //dictionary of time duration of invincibility based on its upgrade level
        //upgrade level is the first number, the duration is the second number
        Dictionary<int, int> invincibilityTime = new Dictionary<int, int>() {
            {1, 5},
            {2, 7},
            {3, 10},
            {4, 14},
            {5, 19}
        };

        //dictionary of time duration of the time powerup based on its upgrade level
        //upgrade level is the first number, the duration is the second number
        Dictionary<int, int> timeTime = new Dictionary<int, int>() {
            {1, 2},
            {2, 4},
            {3, 6},
            {4, 9},
            {5, 12}
        };

        //dictionary of time duration of the star power up based on its upgrade level
        //upgrade level is the first number, the duration is the second number
        Dictionary<int, int> starTime = new Dictionary<int, int>() {
            {1, 2},
            {2, 4},
            {3, 6},
            {4, 9},
            {5, 12}
        };

        //dictionary of time duration of the boost based on its upgrade level
        //upgrade level is the first number, the duration is the second number
        Dictionary<int, int> boostTime = new Dictionary<int, int>() {
            {1, 2},
            {2, 4},
            {3, 6},
            {4, 9},
            {5, 12}
        };

        if (powerUpNumber == 1)
        {
            int upgradeLevel = itemList["Invincibility"].upgradeLevel;
            return invincibilityTime[upgradeLevel];
        }
        else if (powerUpNumber == 2)
        {
            int upgradeLevel = itemList["Time"].upgradeLevel;
            return timeTime[upgradeLevel];
        }
        else if (powerUpNumber == 3)
        {
            int upgradeLevel = itemList["Star"].upgradeLevel;
            return starTime[upgradeLevel];
        }
        else if (powerUpNumber == 2)
        {
            int upgradeLevel = itemList["Boost"].upgradeLevel;
            return boostTime[upgradeLevel];
        }
        else {
            return 0;
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
   
}

