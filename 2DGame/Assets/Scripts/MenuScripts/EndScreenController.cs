using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{

    public GameObject endScreen;
    public GameObject distanceText;
    public GameObject highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Database.gameEnd == true) {
            Time.timeScale = 0f;
            endScreen.SetActive(true);
            distanceText.GetComponent<Text>().text = "Distance: " + ScoreScript.scoreGlobal;

            if (ScoreScript.scoreGlobal > PlayerPrefs.GetFloat("High Score"))
            {
                PlayerPrefs.SetFloat("High Score", ScoreScript.scoreGlobal);
            }

            highScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetFloat("High Score");
        }
    }

    public void MainMenu() {
        Database.gameEnd = false;
        endScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void PlayAgain()
    {
        Database.gameEnd = false;
        endScreen.SetActive(false);
        Time.timeScale = 1f;

        string currentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentScene);
    }
}
