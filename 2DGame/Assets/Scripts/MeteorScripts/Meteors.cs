using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public GameObject meteror;
    public GameObject warning;
    public GameObject canvas;
    public bool meteorsActive;

    float xCoor;
    float yCoor;

    float canvasHeight;
    float canvasWidth;

    Camera cam;
    float camHeight;
    float camWidth;

    float screenMultiplyer;

    //lower bound random range
    float lower;
    //higher bound random range
    float higher;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        //the +1 at the end gives some padding at the bottom
        lower = (camHeight / 2 * -1) + 1;
        //the -1 at the end gives some padding at the top
        higher = (camHeight / 2) - 1;

        canvasHeight = canvas.GetComponent<RectTransform>().rect.height;
        canvasWidth = canvas.GetComponent<RectTransform>().rect.width;

        //the camera height to canvas height ratio
        screenMultiplyer = canvasHeight / camHeight;

        if (meteorsActive == true) {
            //spawns a meteor starting at 15 seconds, and repeats every 30 seconds
            InvokeRepeating("SpawnWarning", 15f, 30f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWarning() {

        //center x
        float camPosX = cam.transform.position.x;
        //center y
        float camPosY = cam.transform.position.y;

        //spawns the meteor off screen to the right
        float xCoorMeteor = camPosX + (camWidth * 2);
        float yCoorMeteor = Random.Range(lower, higher);

        float xCoorWarning = (canvasWidth / 2 ) - 50;
        float yCoorWarning = (yCoorMeteor * screenMultiplyer);

        GameObject myWarning = Instantiate(warning, new Vector3(xCoorWarning, yCoorWarning, 0), Quaternion.identity);
        myWarning.transform.SetParent(canvas.transform, false);

        StartCoroutine(SpawnMeteor(2f, xCoorMeteor, yCoorMeteor));
    }

    //spawns meteor after 2 seconds of the warning spawning
    IEnumerator SpawnMeteor(float count, float xCoor, float yCoor)
    {
        yield return new WaitForSeconds(count);
        Instantiate(meteror, new Vector3(xCoor, yCoor, 0), Quaternion.Euler(0, 0, 0));
    }
}
