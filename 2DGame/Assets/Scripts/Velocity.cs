using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    Vector2 forceVector = new Vector2(220, 0);

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB= GetComponent<Rigidbody2D>();
        PlayerRB.AddForce(forceVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
