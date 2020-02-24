using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        float yPos = gameObject.transform.position.y;

        if (Mathf.Abs(yPos) >= 6f)
        {
            timer += Time.deltaTime;

            if (timer >= 5f || Mathf.Abs(yPos) >= 15f)
            {
                Database.gameEnd = true;
            }

            // Adds a little bit force to push the player back into the screen when out of it so the pleyer...
            // ... can live longer
            float push = yPos < 0 ? 1 : -1;
            Vector2 pushInbounds = new Vector2(0f, push);
            gameObject.GetComponent<Rigidbody2D>().AddForce(pushInbounds);
        }
        else
        {
            timer = 0;
        }

    }


    //runs when player collides with anything on the screen
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "PowerUp")
        {
            Database.gameEnd = true;
        }
    }
}