using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPoweredUp : MonoBehaviour
{
    public static float OldSpeed;
    public static GameObject[] Planets;
    public Transform  PlanetPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Planets = GameObject.FindGameObjectsWithTag("Planet");
        if (PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 4)
        {
            PlanetPrefabs.GetComponent < Attractor >().enabled = false;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enabled = false;
            //Velocity.MaxSpeed = 30f;
            Velocity.forceVector = new Vector2(500, 0);
            Velocity.PlayerRB.AddForce(Velocity.forceVector);
            Debug.Log("Yet");
            OldSpeed = Velocity.speed;
           // Velocity.speed = 30f;
            Debug.Log(Velocity.speed);

        }
    }
}
