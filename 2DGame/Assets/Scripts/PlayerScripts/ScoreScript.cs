using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Transform PlayerPos;
    public float Score, OldScore, NewScore = 0;
    //same thing as "Score" but static so that it can be accessed from other scripts
    public static float scoreGlobal = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        Score = Mathf.Round(PlayerPos.position.x) > Score ? Mathf.Round(PlayerPos.position.x) : Score;
        scoreGlobal = Score;
        ScoreText.text = Score.ToString();
    }
}
