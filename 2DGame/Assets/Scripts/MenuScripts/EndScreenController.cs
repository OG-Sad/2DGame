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
    public GameObject mainMenuButton;
    public GameObject playAgainButton;

    List<int> top10Scores = new List<int>();

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
                //temporarilly set these buttons to false so player can't change scene while new high score is potentially uploading
                mainMenuButton.SetActive(false);
                playAgainButton.SetActive(false);

                PlayerPrefs.SetFloat("High Score", ScoreScript.scoreGlobal);

                //downloads the current high scores and sends the new one to the database if it is high enough
                StartCoroutine("DownloadHighscoresFromDatabase");
            }

            highScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetFloat("High Score");
        }
    }

    string GetUsername(int score) {
        string username = "";

        for (int i = 0; i < 10; i++)
        {
            if (score > top10Scores[i])
            {
                print("score:" + score);
                print("other:" + top10Scores[i]);
                if (i == 0)
                {
                    username = "1";
                    break;
                }
                else if (i == 1)
                {
                    username = "2";
                    break;
                }
                else if (i == 2)
                {
                    username = "3";
                    break;
                }
                else if (i == 3)
                {
                    username = "4";
                    break;
                }
                else if (i == 4)
                {
                    username = "5";
                    break;
                }
                else if (i == 5)
                {
                    username = "6";
                    break;
                }
                else if (i == 6)
                {
                    username = "7";
                    break;
                }
                else if (i == 7)
                {
                    username = "8";
                    break;
                }
                else if (i == 8)
                {
                    username = "9";
                    break;
                }
                else if (i == 9)
                {
                    username = "10";
                    break;
                }
            }
        }
        return username;
    }

    //pushes back all of the high scores below the newest high score back one slot
    void PushScoresBack(string username) {
        int highScorePlace = int.Parse(username);

        for (int i = highScorePlace + 1; i <= 10; i++) {
            StartCoroutine(UploadNewHighscore(i.ToString(), top10Scores[i - 2]));
        }
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        const string privateCode = "g5IdeqN0PECOdCyRIVBqiAN8aJZjof5kmZyR_3i1Lrzg";
        const string publicCode = "5e7d38eefe232612b8e47de9";
        const string webURL = "http://dreamlo.com/lb/";

        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    //downloads the current high scores and sends the new one to the database if it is high enough
    IEnumerator DownloadHighscoresFromDatabase()
    { 
        const string privateCode = "g5IdeqN0PECOdCyRIVBqiAN8aJZjof5kmZyR_3i1Lrzg";
        const string publicCode = "5e7d38eefe232612b8e47de9";
        const string webURL = "http://dreamlo.com/lb/";

        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            GetInfo(www.text);
            //if the score is more than the 10th best score
            if (ScoreScript.scoreGlobal > top10Scores[9])
            {
                string username = GetUsername((int)ScoreScript.scoreGlobal);
                //the function is only necessary if the new high score is better than the 10th best
                if (username != "10")
                {
                    PushScoresBack(username);
                }
                //uploads the new high score
                StartCoroutine(UploadNewHighscore(username, (int)ScoreScript.scoreGlobal));

                mainMenuButton.SetActive(true);
                playAgainButton.SetActive(true);
            }
            else {
                mainMenuButton.SetActive(true);
                playAgainButton.SetActive(true);
            }
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void GetInfo(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < 10; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            top10Scores.Add(score);
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
