using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camera moves at same speed as player in x direction
public class PlayerScript : MonoBehaviour
{
    public Transform player;
    public Camera PlayerCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.position = new Vector3(player.position.x + .1f, /*player.position.y + .01f*/0, 0);
        PlayerCam.transform.position = new Vector3(player.position.x, 0, -10f);



    }
}
