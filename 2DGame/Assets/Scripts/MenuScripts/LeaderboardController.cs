using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{

	const string privateCode = "g5IdeqN0PECOdCyRIVBqiAN8aJZjof5kmZyR_3i1Lrzg";
	const string publicCode = "5e7d38eefe232612b8e47de9";
	const string webURL = "http://dreamlo.com/lb/";

	public List<int> top10Scores = new List<int>();

	public Text highScoreText;

	GameObject highscoreSlot;

	// Start is called before the first frame update
	void Start()
	{
		highscoreSlot = GameObject.Find("Canvas/Panel/Top 10/");
		highscoreSlot.SetActive(false);

		string highScore = PlayerPrefs.GetFloat("High Score").ToString();

		highScoreText.text = "High Score: " + highScore;

		DownloadHighscores();
	}

	//resets the PlayerPrefs high score
	public void Reset()
	{
		PlayerPrefs.DeleteAll();

		highScoreText.text = "High Score: 0";
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscores(www.text);

			for (int i = 0; i < 10; i++)
			{
				GameObject highscoreSlot = GameObject.Find("Canvas/Panel/Top 10/" + (i + 1).ToString());
				highscoreSlot.GetComponent<Text>().text = (i + 1).ToString() + ". " + top10Scores[i].ToString();
			}

			highscoreSlot.SetActive(true);
		}
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

		for (int i = 0; i < 10; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			int score = int.Parse(entryInfo[1]);
			top10Scores.Add(score);
		}
	}
}