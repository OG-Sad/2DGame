using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Velocity : MonoBehaviour
{
    public bool testing = false;
    public CircleCollider2D Col;
    public Transform player;
    public float MinSpeed = 5f;
    public static float MaxSpeed = 20f, speed;
    public bool isLevel;

    public static Rigidbody2D PlayerRB;
    public static Vector2 forceVector = new Vector2(300, 0);
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
        speed = v.sqrMagnitude;// (PlayerRB.velocity);  // test current object speed
      
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
        float score = isLevel ? 0 : GameObject.Find("Score").GetComponent<ScoreScript>().Score;

        MinSpeed = MinSpeed >= MaxSpeed ? MaxSpeed : MinSpeed + (score / 40);

        if (testing == true) {
            player.localPosition = new Vector2(player.position.x + .1f, 0);   
        }

        float yPos = player.position.y;

        if (Mathf.Abs(yPos) >= 6f) {
            timer += Time.deltaTime;
            
            if (timer >= 5f || Mathf.Abs(player.position.y) >= 15f) {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
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
