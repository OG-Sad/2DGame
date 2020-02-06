using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;
    
    private Rigidbody2D body;
    public float speed = 10f;

    Vector2 velocity, desiredVelocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        desiredVelocity = new Vector2(1f, 0f) * maxSpeed;
    }

    void FixedUpdate()
    {
        float acceleration = maxAcceleration;
        float maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = 
            Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = 
            Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);
        body.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        // Debug.Log("Collision");
    }
}
