﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    //if the data is reset, the PlayerPrefs default the values at 0
    public static int currentLevel = PlayerPrefs.GetInt("currentLevel");
    //the highest level the player has achieved; starts at 0
    public static int highestCurrentLevel = PlayerPrefs.GetInt("highestCurrentLevel");
    public static bool currentLevelEnded;
}