﻿using System.Collections;
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
        SceneManager.LoadScene("PlanetSpawningTest");
        GamePaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "PlanetSpawningTest");
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
}