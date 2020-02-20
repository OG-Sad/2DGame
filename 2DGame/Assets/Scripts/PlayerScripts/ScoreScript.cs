using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Transform PlayerPos;
    public float Score = 0 , OldScore, NewScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        Score = Mathf.Round(PlayerPos.position.x) > Score ? Mathf.Round(PlayerPos.position.x) : Score;
        ScoreText.text = Score.ToString();
    }
}
