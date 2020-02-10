using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Transform StandardPowerup, Player;
    public static Transform PowerUp;
    float yPos = 0, PowerUpGo = 0;
    public static bool PowerUpTrue = false, PlayerPoweredUp = false;
    float seconds = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpGo = Random.Range(0, 5);
        //Debug.Log(PowerUpGo);
        
        if (PowerUpGo == 4 && PowerUpTrue == false)
        {
            //EditorApplication.isPaused = true;
            SpawnPowerUp();
        }
        if(StandardPowerup.position.x <= Player.position.x + 10f)
        {
            Destroy(PowerUp);
            PowerUpTrue = false;
        }
        if (PlayerPoweredUp == true)
        {
            seconds += Time.deltaTime;
            if (seconds >= 6) {
                //Col.enabled = true;
                PlayerPoweredUp = false;
                seconds = 0;
            }
        }
    }

    void SpawnPowerUp()
    {
        //EditorApplication.isPaused = true;
        PowerUp = Instantiate(StandardPowerup);
        //yPos = Random.Range(-4.5f, 4.5f);
        yPos = 0;
        PowerUp.localPosition = new Vector2(Player.position.x + 10f, yPos);
        PowerUpTrue = true;
        
    }
}
