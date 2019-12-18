using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoll : MonoBehaviour
{
    Material material;
    Vector2 offset;
    public float xVelocity;
    public Transform BackgroundSpeed;



   private void Awake()
    {
        material = GetComponent<Renderer>().material;
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Speed = GameObject.Find("Player");
        BackgroundSpeed.position = new Vector3(Speed.transform.position.x, 0f, 10f);
       

        material.mainTextureOffset += offset * Time.deltaTime * .25f;
    }
}
