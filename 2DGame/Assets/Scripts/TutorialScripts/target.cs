using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class target : MonoBehaviour
{
    public Transform targetObject;
    //public static bool targetHit = false;
    //GameObject realplayer;
    // Start is called before the first frame update
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(originalPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //targetHit = true;
            //Debug.Log("Hit");
            //Destroy(gameObject);
            Database.targetsHit = Database.targetsHit + 1;

        }

    }
}
