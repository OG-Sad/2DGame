using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Velocity : MonoBehaviour
{
    public bool testing = false;
    public Transform player;
    Rigidbody2D PlayerRB;
    Vector2 forceVector = new Vector2(150, 0);
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (testing == false) {
            PlayerRB = GetComponent<Rigidbody2D>();
            PlayerRB.AddForce(forceVector);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (testing == true) {
            player.localPosition = new Vector2(player.position.x + .1f, 0);   
        }

        if (Mathf.Abs(player.position.y) >= 5f) {
            timer += Time.deltaTime;
            if (timer >= 5f || Mathf.Abs(player.position.y) >= 15f) {
                SceneManager.LoadScene("PlanetSpawningTest");
            }
        }
        else {
            timer = 0;
        }
    }
}
