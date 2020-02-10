using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Transform PlayerPos;
    private float Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Score = Mathf.Round(PlayerPos.position.x);
        ScoreText.text = Score.ToString();
    }
}
