using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Velocity : MonoBehaviour
{
    public bool testing = false;
    public CircleCollider2D Col;
    public Transform player;
    public float MaxSpeed = 5f;
    Rigidbody2D PlayerRB;
    Vector2 forceVector = new Vector2(250, 0);
    float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        if (testing == false) {
            PlayerRB = GetComponent<Rigidbody2D>();
            PlayerRB.AddForce(forceVector);
        }
        
    }
    void FixedUpdate()
    {
        var v = PlayerRB.velocity;
        float speed = v.sqrMagnitude;// (PlayerRB.velocity);  // test current object speed
      
        if (speed > MaxSpeed)
        {
            float brakeSpeed = speed - MaxSpeed;  // calculate the speed decrease
        
            Vector3 normalisedVelocity = PlayerRB.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value
        
            PlayerRB.AddForce(-brakeVelocity);  // apply opposing brake force
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (testing == true) {
            player.localPosition = new Vector2(player.position.x + .1f, 0);   
        }

        float yPos = player.position.y;

        if (Mathf.Abs(yPos) >= 6f) {
            timer += Time.deltaTime;
            
            if (timer >= 5f || Mathf.Abs(player.position.y) >= 15f) {
                SceneManager.LoadScene("PlanetSpawningTest");
            }
            
            // Adds a little bit force to push the player back into the screen when out of it so the pleyer...
            // ... can live longer
            float push = yPos < 0 ? 1 : -1;
            Vector2 pushInbounds = new Vector2(0f, push);
            PlayerRB.AddForce(pushInbounds);
        }
        else {
            timer = 0;
        }
      
    }
}
