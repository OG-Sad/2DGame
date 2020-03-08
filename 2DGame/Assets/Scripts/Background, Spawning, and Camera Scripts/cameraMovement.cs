using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    // Public variable to store a reference to the player game object
    GameObject player;
    bool smoothcamera = false;
    public bool CameraChange = false;
    float a = 0.01f;

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
    void LateUpdate()
    {
        if (CameraChange)
        {


            Debug.Log(smoothcamera);

            if (Attractor.orbittest)
            {
                Debug.Log("orbit");
                smoothcamera = true;
                // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            }
            if (Attractor.orbittest == false && smoothcamera)
            {
                Debug.Log("in boys");
                float offsetY = offset.y + (player.transform.position.y * .15f);
                transform.position = new Vector3(transform.position.x + a, offsetY, transform.position.z);
                //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                a += .001f;
                Debug.Log(offset.x);
                Debug.Log(a);
                if (player.transform.position.x + offset.x <= transform.position.x)
                {

                    smoothcamera = false;
                    a = .01f;
                }
            }

            else if (Attractor.orbittest == false)
            {

                Debug.Log("not orbit");
                float offsetY = offset.y + (player.transform.position.y * 0.15f);
                // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
                transform.position = new Vector3(player.transform.position.x + offset.x, offsetY, transform.position.z);
            }
            
        }
        else
        {
            float offsetY = offset.y + (player.transform.position.y * 0.15f);
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = new Vector3(player.transform.position.x + offset.x, offsetY, transform.position.z);
        }
    }

   

}

