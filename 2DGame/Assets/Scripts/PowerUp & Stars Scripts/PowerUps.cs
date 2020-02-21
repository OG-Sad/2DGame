using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Transform InvinciblePowerUp, TimePowerUp, StarPowerUp, BoostPowerUp, Player, Star;
    public static Transform PowerUp, StarSpawning;
    float yPos = 0, timer = 0, seconds = 0;
    public static bool PowerUpTrue = false, PlayerPoweredUp = false, PlayerPotentialPowerUp = false;
    public static int ChoosePowerUp = 0, PowerUpGo = 0, StarGo;
    public static bool RespawnStar = false;
    


    // Update is called once per frame
    void Update()
    {
        //Every 10 seconds a power up can spawn
        timer += Time.deltaTime;
        if (timer >= 10)

        {
            //1/5 times a power up can spawn, it will spawn
            PowerUpGo = Random.Range(0, 5);
            timer = 0;
            if (PowerUpGo == 4)// && PowerUpTrue == false)
            {
                //EditorApplication.isPaused = true;
                SpawnPowerUp();
            }
        }
        //Every 20 seconds a Star can spawn
        
        if (timer >= 20)
        {
            //1/5 times chance a Star can spawn
            StarGo = Random.Range(0, 4);
            timer = 0;

            if (StarGo == 1)
            {
                //EditorApplication.isPaused = true;
                SpawnStar();
            }
        }

        //Debug.Log(PowerUpGo);
        if (PlayerPotentialPowerUp == true && Input.touchCount > 1)
        {
            PlayerPoweredUp = true;
            
        }

        if (PlayerPoweredUp == true)
        {

            DuringPowerUp();

        }
        if (RespawnStar)
        {
            SpawnStar();
        }
        Debug.Log(Input.touchCount);
    }

    void SpawnPowerUp()
    {
        ChoosePowerUp = Random.Range(0, 4);
        if (ChoosePowerUp == 1)
        {
            //EditorApplication.isPaused = true;
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
        
        seconds += Time.unscaledDeltaTime;

        if (seconds >= 6 && ChoosePowerUp == 1)
        {

            PlayerPoweredUp = false;
            seconds = 0;

        }

        if (seconds >= 6 &&  ChoosePowerUp == 2)
        {

            Time.timeScale = 1f;
            PlayerPoweredUp = false;
            seconds = 0;
            
            
        }
        
        if (seconds >= 6 && ChoosePowerUp == 3)
        {

            PlayerPoweredUp = false;
            seconds = 0;

        }

        if (seconds >= 6 && ChoosePowerUp == 4)
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enabled = true;
            foreach (GameObject Plan in BoostPoweredUp.Planets)
            {
               Plan.GetComponent<Attractor>().enabled = true;
            }
            PlayerPoweredUp = false;
            Velocity.speed = BoostPoweredUp.OldSpeed;
            seconds = 0;

        }
    }

     void SpawnStar()
    {
        var yPoss = 0;
        //EditorApplication.isPaused = true;
        StarSpawning = Instantiate(Star);
        //yPos = Random.Range(-4.5f, 4.5f);
        StarSpawning.localPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 20f, yPoss);

    }
}

