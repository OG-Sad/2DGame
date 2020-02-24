using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevels() {
        SceneManager.LoadScene("Level Select");
    }

    public void GoToArcade() {
        //go to arcade
    }

    public void ResetData() {
        PlayerPrefs.DeleteAll();
        //if the data is reset, the PlayerPrefs default the values at 0
        Database.currentLevel = PlayerPrefs.GetInt("currentLevel");
        Database.highestCurrentLevel = PlayerPrefs.GetInt("highestCurrentLevel");
}
}
