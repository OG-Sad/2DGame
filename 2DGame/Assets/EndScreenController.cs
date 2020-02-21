using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{

    public GameObject endScreen;
    public GameObject distanceText;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Database.planetCollision == true) {
            endScreen.SetActive(true);
            distanceText.GetComponent<Text>().text = "Distance: " + Database.finalScore;
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("MenuScene");
        Database.planetCollision = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlanetSpawningTest");
        Database.planetCollision = false;
    }
}
