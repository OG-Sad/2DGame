using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Database
{
    //if the data is reset, the PlayerPrefs default the values at 0
    public static int currentLevel = PlayerPrefs.GetInt("currentLevel");
    //the highest level the player has achieved; starts at 0
    public static int highestCurrentLevel = PlayerPrefs.GetInt("highestCurrentLevel");
    public static bool currentLevelEnded;

    public static bool gameEnd = false;
    //the score when the player dies
    public static float finalScore;
    public static bool isOrbiting = false;
    public static Vector2 orbitPlanetPos;

    public static int targetsHit = 0;
    
    
}
