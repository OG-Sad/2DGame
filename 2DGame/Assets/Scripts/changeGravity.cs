using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGravity : MonoBehaviour
{
    public GameObject planet, ring1;
    public float threshold = .3f, timerThreshold = .15f, massMultiplier = 8, slightMassMultiplier = 3, divisionDecider = .1f, ringSize = 2.5f;
    public bool test = false, doubleTapGrav;
    private Vector3 startPos;
    private bool directionDetermined, direction, isBeingHeld, gravityRate, startTimer, taps, firstTap, firstDoubleTap;
    private float planetMass, displacement, xDisplacement = 0, yDisplacement = 0, startMass, timer = 0, doubleTapTimer = 0, lastPosition, mouseDir, planetMassCheck, massHolder, secondSecondCounter;
    private Vector3 cameraStartPos;
    Rigidbody2D planetRB;
    SpriteRenderer m_SpriteRenderer;
    new GameObject camera;

    
    void Awake() {

        planetRB = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        planetMassCheck = planet.name == "bigPlanet(Clone)" || planet.name == "bigPlanet" ? 100 : 50;

        ring1.SetActive(true);
        DisplayRings(planetRB.mass);
    }

    // Update is called once per frame
    void Update() {

         if((isBeingHeld || (secondSecondCounter > 0 && secondSecondCounter < .2f)) && !doubleTapGrav && !directionDetermined) {
            secondSecondCounter += Time.deltaTime;
            if(!isBeingHeld && secondSecondCounter < .2f) {
                //taps = true;
                secondSecondCounter = 0;
                firstDoubleTap = !firstDoubleTap;
                if (firstDoubleTap == true) {
                    massHolder = planetRB.mass;
                    planetRB.mass = 0;
                }
                else {
                    planetRB.mass = massHolder;
                }
                DisplayRings(planetRB.mass);
            }
        }
        else {
            secondSecondCounter = 0;
            taps = false;
        }


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
                
                taps = false;
                firstDoubleTap = false;

                if (directionDetermined == false) {
                    // Determines if direction is horizontal or vertical (X: true, Y: false).
                    direction = Mathf.Abs(xDisplacement) >= Mathf.Abs(yDisplacement) ? true : false; 
                    
                    startMass = planetRB.mass;
                }

                displacement = direction == true ? xDisplacement : yDisplacement;
                mouseDir = direction == true ? mousePos.x : mousePos.y;
                
                gravity(displacement, startMass, gravityRate);

                directionDetermined = true;

                if (timer > timerThreshold) {
                    lastPosition = mouseDir;
                    timer = 0;
                } 

                gravityRate = changeSpeedCheck(lastPosition, mouseDir, timer, gravityRate);

            }
        }
        
        
        if (((startTimer == true || (doubleTapTimer > 0.01f && doubleTapTimer < 0.25f)) && taps == false) && doubleTapGrav) {
            doubleTapTimer += Time.deltaTime;
            if (isBeingHeld == false) {
                firstTap = true;
            }
            if (isBeingHeld == true && firstTap == true) {
                firstDoubleTap = !firstDoubleTap;
                if (firstDoubleTap == true) {
                    massHolder = planetRB.mass;
                    planetRB.mass = 0;
                }
                else {
                    planetRB.mass = massHolder;
                }
                taps = true;
                DisplayRings(planetRB.mass);
            }
        }
        else {
            doubleTapTimer = 0;
            firstTap = false;
            taps = false;
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
            startTimer = true;
        }
    }



    private void OnMouseUp() {
        // Resets values, doesn't reset mass of planet or color
        isBeingHeld = false;
        startTimer = false;
        directionDetermined = false;
        displacement = 0;
        timer = 0;
    }



    // Gravity control
    public void gravity(float displace, float originalMass, bool gravRate) {
        // gravRate is true = normal, false = sligt
        float multiplier = gravRate ? massMultiplier : slightMassMultiplier;
        multiplier = planet.name == "bigPlanet(Clone)" || planet.name == "bigPlanet" ? 1.5f * multiplier : 1 * multiplier; 
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

        DisplayRings(newMass); 
    }



    // Decides the rate the the gravity changes at. |
    // | Works by getting passed a previous position of the mouse(PPM), the current position...
    // ... of the mouse(CPM), the time passed since the previous position was updated, and...
    // ... the gravity rate. 
    public bool changeSpeedCheck (float prePosition, float mousePosition, float time, bool gravRate) {
        float distanceLastToCurrent = Mathf.Abs(prePosition - mousePosition);                

        if (time > 0.05f && distanceLastToCurrent > 0.01f) {
            float holder = Mathf.Abs(distanceLastToCurrent / time);
            //Debug.Log(holder);
            if (holder > divisionDecider) {
                gravRate = true;
            }
            else {
                gravRate = false;
            }             
        }

        return gravRate;
    }



    private void DisplayRings(float mass) {
        float fraction = mass / planetMassCheck;

        if (mass <= 0) {
            ring1.transform.localScale = new Vector3(0.0001f, 0.0001f, 1);
        }
        else if (mass >= planetMassCheck) {
            ring1.transform.localScale = new Vector3(ringSize, ringSize, 1);
        }
        else {
            ring1.transform.localScale = new Vector3(ringSize * fraction, ringSize * fraction, 1);
        }

        m_SpriteRenderer.color = planet.name == "bigPlanet(Clone)" || planet.name == "bigPlanet" ? new Color(1f - fraction, 1f, 1f) : new Color(1f, 1f - fraction, 1f);
    }
}