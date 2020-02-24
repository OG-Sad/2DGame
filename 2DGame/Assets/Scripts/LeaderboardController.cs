using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{

    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        string highScore = PlayerPrefs.GetFloat("High Score").ToString();

        highScoreText.text = "High Score: " + highScore;
    }

    //resets the PlayerPrefs high score
    public void Reset() {
        PlayerPrefs.DeleteAll();

        highScoreText.text = "High Score: 0";
    }
}
