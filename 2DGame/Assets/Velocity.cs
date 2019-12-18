using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public Transform planet;
    public Transform player;
    Rigidbody2D rbPlayer;
    Collider2D colliderPlayer;
    public float VelNum = 10;
    float angle = 0;
    Vector2 velocityVector = new Vector2(4, 0);
    Vector2 attractFactor = new Vector2(0, 0);
    private bool Hit = false;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        colliderPlayer = GetComponent<BoxCollider2D>();
        velocityVector.x = VelNum;
        rbPlayer.velocity = velocityVector;
        //Physics2D.IgnoreCollision(planet.GetComponent<CircleCollider2D>(), player.GetComponent<BoxCollider2D>());
        Debug.Log(velocityVector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.GetComponent<BoxCollider2D>().IsTouching(planet.GetComponent<PolygonCollider2D>())){
            Hit = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        velocityVector = rbPlayer.velocity;
        Debug.Log("before: "+rbPlayer.velocity);

        attractFactor = rbPlayer.velocity;
        angle = Mathf.Atan2(attractFactor.y,attractFactor.x);
        velocityVector.y = Mathf.Sin(angle) * VelNum;
        velocityVector.x = Mathf.Cos(angle) * VelNum;

        //if (rbPlayer.velocity.x < VelNum && Hit==false)
        //{
        //    velocityVector.x=velocityVector.x+VelNum;
        //    rbPlayer.velocity = velocityVector;
        //}
        //Debug.Log(velocityVector);

        rbPlayer.velocity = velocityVector;
        Debug.Log("after: " + rbPlayer.velocity);



        if (Hit == true)
        {
            velocityVector.x = 0;
            velocityVector.y = 0;
            rbPlayer.velocity=velocityVector;
            //player.GetComponent<SpriteRenderer>();

        }
        if (Input.touchCount > 0)
        {
            planet.GetComponent<PointEffector2D>().forceMagnitude--;
            //VelNum++;
            //Debug.Log(VelNum);
        }
    }
}
