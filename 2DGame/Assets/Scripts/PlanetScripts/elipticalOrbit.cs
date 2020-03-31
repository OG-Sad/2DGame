using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elipticalOrbit : MonoBehaviour
{
    GameObject Player;
    
    void start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // Variables: player, velocity, elipsePoint, and planet location
    void elipseOrbit(Vector2 playerVel, Vector2 elipsePointPos, Vector2 planetPos) {
        
        // Calculate the semi-major axis: a
        // a = cube root((G * M * T^2) / (4 * PI^2))
        
        
        // Period: T = 2 * PI * sqrt(a^3 / u)
        // a = orbit's semi-major axis
        // u = GM (where G is standard gravitational constant, and M is the mass of the more massive body)


    }

}
