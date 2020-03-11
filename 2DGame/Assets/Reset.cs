using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject playerPrefab;
   // GameObject realplayer;
    // Start is called before the first frame update
    void Start()
    {
        //realplayer = playerPrefab;
        //Instantiate(realplayer);
        Instantiate(playerPrefab);
    }


    // Update is called once per frame
    void Update()
    {
        if (target.targetHit == true)
        {
            var realplayer = playerPrefab;
            //  Destroy(realplayer);
           // Destroy(realplayer);
            //realplayer = playerPrefab;
            //Instantiate(playerPrefab);
        }
    }
}
