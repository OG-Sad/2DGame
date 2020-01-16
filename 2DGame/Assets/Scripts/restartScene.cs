using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour {

    public void RestartGame() {
        SceneManager.LoadScene("PlanetSpawningTest");    
    }
}