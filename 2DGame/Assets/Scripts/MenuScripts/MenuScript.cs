using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    public static void Restart()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Debug.Log("Resumed");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Paused");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        GamePaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "PlanetSpawningTest");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(sceneName: "LevelSelect");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(sceneName: "Tutorial");
    }

    public void Level_1Select()
    {
        SceneManager.LoadScene(sceneName: "Level 1");
    }

    public void Level_2Select()
    {
        SceneManager.LoadScene(sceneName: "Level 2");
    }

    public void Level_3Select()
    {
        SceneManager.LoadScene(sceneName: "Level 3");
    }

    public void Level_4Select()
    {
        SceneManager.LoadScene(sceneName: "Level 4");
    }

    public void Level_5Select()
    {
        SceneManager.LoadScene(sceneName: "Level 5");
    }

    public void Level_CowSelect()
    {
        SceneManager.LoadScene(sceneName: "Cow Level");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(sceneName: "MenuScene");
        GamePaused = false;
        Time.timeScale = 1f;

    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Debug.Log("Resumed");
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Paused");
    }

    public void Shop()
    {
        SceneManager.LoadScene(sceneName: "Shop");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene(sceneName: "Leaderboard");
    }
}
