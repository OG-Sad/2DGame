using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    public Animator transition;

    public float transitionTime = 1f;

    public static void Restart()
    {
        GamePaused = false;
    }

    void Update()
    {
        //Checking to see if the player paused the game
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

    //Resume Game
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Debug.Log("Resumed");
    }

    //Pause Game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Paused");
    }

    //Restart the Game
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        GamePaused = false;
    }

    //Main Menu Buttons
    public void StartGame()
    {
        StartCoroutine(LoadGame(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadGame(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void LevelSelect()
    {
        StartCoroutine(LoadLevelSelect(SceneManager.GetActiveScene().buildIndex + 2));
    }

    IEnumerator LoadLevelSelect(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Leaderboard()
    {
        StartCoroutine(LoadLeaderboard(SceneManager.GetActiveScene().buildIndex + 4));
    }

    IEnumerator LoadLeaderboard(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Shop()
    {
        StartCoroutine(LoadShop(SceneManager.GetActiveScene().buildIndex + 3));
    }

    IEnumerator LoadShop(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    //Level Select Buttons
    public void Tutorial()
    {
        StartCoroutine(LoadTutorial(SceneManager.GetActiveScene().buildIndex + 3));
    }
    IEnumerator LoadTutorial(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Level_1Select()
    {
        StartCoroutine(LoadLevel1(SceneManager.GetActiveScene().buildIndex + 4));
    }
    IEnumerator LoadLevel1(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Level_2Select()
    {
        StartCoroutine(LoadLevel2(SceneManager.GetActiveScene().buildIndex + 5));
    }
    IEnumerator LoadLevel2(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
    public void Level_3Select()
    {
        StartCoroutine(LoadLevel3(SceneManager.GetActiveScene().buildIndex + 6));
    }
    IEnumerator LoadLevel3(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Level_4Select()
    {
        StartCoroutine(LoadLevel4(SceneManager.GetActiveScene().buildIndex + 7));
    }
    IEnumerator LoadLevel4(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Level_5Select()
    {
        StartCoroutine(LoadLevel5(SceneManager.GetActiveScene().buildIndex + 8));
    }
    IEnumerator LoadLevel5(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Level_CowSelect()
    {
        StartCoroutine(LoadCow(SceneManager.GetActiveScene().buildIndex + 9));
    }
    IEnumerator LoadCow(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    //Pause Menu Buttons
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

}
