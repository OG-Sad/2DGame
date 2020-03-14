using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    // Public variable to store a reference to the player game object
    GameObject camera;
    bool smoothcamera = false;
    public bool CameraChange = false;
    float a = 1f;

    // Private variable to store the offset distance between the player and camera
    private Vector3 offset;
    private Vector3 combo;
    private Vector3 velocity = Vector3.zero;

    void Awake() {
        camera = GameObject.FindGameObjectWithTag("Player");
    }
    // Use this for initialization
    void Start () 
    {
        // Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - camera.transform.position;
    }
    private void LateUpdate()
    {
        if ((PowerUps.PlayerPoweredUp && PowerUps.ChoosePowerUp == 4) | (!Attractor.orbittest && !smoothcamera))
        {
            Attractor.orbittest = false;
            float offsetY = offset.y + (camera.transform.position.y * 0.15f);
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = new Vector3(camera.transform.position.x + offset.x, offsetY, transform.position.z);
        }
    }
    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {


        if (CameraChange)
        {
            if ((PowerUps.PlayerPoweredUp && PowerUps.ChoosePowerUp == 4) | (!Attractor.orbittest && !smoothcamera))
            {
               
            }

            

            else if  (Attractor.orbittest)
            {
                smoothcamera = true;

                // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            }
            else if (Attractor.orbittest == false && smoothcamera)
            {
                float offsetY = offset.y + (camera.transform.position.y * .15f);
                //transform.position = new Vector3(transform.position.x + a, offsetY, transform.position.z);
                float smoothSpeed = .5f;
                combo = new Vector3(camera.transform.position.x + offset.x, offsetY, transform.position.z);
                //Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, combo, a);
                transform.position = Vector3.SmoothDamp(transform.position, combo, ref velocity, a);
                a -= .005f;

                //transform.position = smoothedPosition;

                //Debug.Log(offset.x);
                //Debug.Log(a);

               if (transform.position.x >= camera.transform.position.x + offset.x)
               {
                    smoothcamera = false;
                    a = 1f;
               }



                /*
                else
                {
                    a += .01f;
                }
                

                if (player.transform.position.x + offset.x -.05f <= transform.position.x)
                {
                    Debug.Log("In");
                    smoothcamera = false;
                    a = .01f;
                }
                
            
               */
                
                
            }

            }
            else
            {
                float offsetY = offset.y + (camera.transform.position.y * 0.15f);
                // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
                transform.position = new Vector3(camera.transform.position.x + offset.x, offsetY, transform.position.z);
            }
        


    }
}

