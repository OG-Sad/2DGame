using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGravity : MonoBehaviour
{
    public GameObject planet;
    GameObject camera = null;
    public float threshold = .3f, timerThreshold = .15f, massMultiplier = 8, slightMassMultiplier = 3, divisionDecider = .1f;
    public bool test = false;
    private Vector3 startPos;
    private bool directionDetermined = false, direction, isBeingHeld = false, gravityRate = false;
    private float planetMass, displacement, xDisplacement = 0, yDisplacement = 0, startMass, timer = 0, lastPosition, mouseDir, planetMassCheck;
    private Vector3 cameraStartPos;
    Rigidbody2D planetRB;
    SpriteRenderer m_SpriteRenderer;

    
    void Awake() {
        planetRB = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        planetMass = planetRB.mass;

        m_SpriteRenderer.color = planet.name == "bigPlanet(Clone)" ? new Color(.5f, 0f, 0f) : new Color(0, .5f, 0);

        planetMassCheck = planet.name == "bigPlanet(Clone)" ? 100 : 50;
    }

    // Update is called once per frame
    void Update() {

        if (isBeingHeld == true) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            timer += Time.deltaTime;
            
            if (test) {
                Debug.Log("Start X: " + startPos.x);
                Debug.Log("Start Y: " + startPos.y);  
                Debug.Log("Current X: " + mousePos.x);  
                Debug.Log("Current Y: " + mousePos.y);  
                Debug.Log("--------------------------------------------");
            }
              
            // Get Difference of X and Y start positions and current positions
            // Accounts for the movement of the camera so it doesn't affect the gravity control
            Vector3 cameraDifference = camera.transform.position - cameraStartPos;
            xDisplacement = (mousePos.x - cameraDifference.x) - startPos.x;
            yDisplacement = (mousePos.y - cameraDifference.y) - startPos.y;
              

            // If player moves away from the center of the planet 5 units in any direction...
            // ...determine whether it is horizontal or vertical and set it so the player...
            // ...can only change the gravity in that direction while pressing on the planet...
            // ... Until then, gravity function isn't called.
            if ((Mathf.Abs(xDisplacement) > threshold || Mathf.Abs(yDisplacement) > threshold) || directionDetermined == true) {
                
                if (directionDetermined == false) {
                    // Determines if direction is horizontal or vertical (X: true, Y: false).
                    direction = Mathf.Abs(xDisplacement) >= Mathf.Abs(yDisplacement) ? true : false; 
                    startMass = planetRB.mass;
                    //gravityRate = timer < timerThreshold ? true : false;
                    //timer = 0;
                    //Debug.Log(gravityRate);
                    //Debug.Log(timer);
                }

                displacement = direction == true ? xDisplacement : yDisplacement;
                mouseDir = direction == true ? mousePos.x : mousePos.y;

                // More control over gravity of planet if distance between last and current mouse position
                
                gravity(displacement, startMass, gravityRate);

                directionDetermined = true;

                if (timer > timerThreshold) {
                    lastPosition = mouseDir;
                    timer = 0;
                } 

                gravityRate = changeSpeedCheck(lastPosition, mouseDir, timer, gravityRate);

            }
        }

        
    }

    private void OnMouseDown() {
        if (Input.GetMouseButtonDown(0) && isBeingHeld == false) {
            // Start position of the mouse
            startPos = Input.mousePosition;
            startPos = Camera.main.ScreenToWorldPoint(startPos);

            // Start position of the camera
            cameraStartPos = camera.transform.position;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp() {
        // Resets values, doesn't reset mass of planet or color
        isBeingHeld = false;
        directionDetermined = false;
        displacement = 0;
        timer = 0;
    }

    // Gravity control
    public void gravity(float displace, float originalMass, bool gravRate) {
        // gravRate is true = normal, false = sligt
        float multiplier = gravRate ? massMultiplier : slightMassMultiplier;
        multiplier = planet.name == "bigPlanet(Clone)" ? 2 * multiplier : 1 * multiplier; 
        float newMass = originalMass + (displace * multiplier);
        
        // Gravity Parameters
        if (newMass <= 0) {
            planetRB.mass = 0;
        }
        else if (newMass >= planetMassCheck) {
            planetRB.mass = planetMassCheck;
        }
        else {
            planetRB.mass = newMass;
        }

        float color = newMass / planetMassCheck;
        m_SpriteRenderer.color = planet.name == "bigPlanet(Clone)" ? new Color(color, 0f, 0f) : new Color(0, color, 0);
        //Debug.Log(planetRB.mass);
    }

    // Decides the rate the the gravity changes at. |
    // | Works by getting passed a previous position of the mouse, the current position...
    // ... of the mouse, the time passed since the previous position was updated, and...
    // ... the gravity rate.  
    public bool changeSpeedCheck (float prePosition, float mousePosition, float time, bool gravRate) {
        float distanceLastToCurrent = Mathf.Abs(prePosition - mousePosition);                

        if (time > 0.05f && distanceLastToCurrent > 0.01f) {
            float holder = Mathf.Abs(distanceLastToCurrent / time);
            Debug.Log(holder);
            if (holder > divisionDecider) {
                gravRate = true;
            }
            else {
                gravRate = false;
            }             
        }

        return gravRate;
    }
}