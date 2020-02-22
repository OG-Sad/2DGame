﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    // Public variable to store a reference to the player game object
    new GameObject player;        

    // Private variable to store the offset distance between the player and camera
    private Vector3 offset;            

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Use this for initialization
    void Start () 
    {
        // Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        float offsetY = offset.y + (player.transform.position.y * 0.15f);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(player.transform.position.x + offset.x, offsetY, transform.position.z);
    }
}
