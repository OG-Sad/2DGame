using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform Player;
    public Transform BackgroundType;
    Transform item = null;
    List<Transform> Backgrounds;
    Vector3 lastPlayerPos;


    void Awake() {
        Backgrounds = new List<Transform>();
        Backgrounds.Add(BackgroundType);
    }
    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPos = Player.position;
    }

    // Update is called once per frame
    void Update() 
    {
        Vector3 movement = (lastPlayerPos - Player.position) * Time.deltaTime;
        Backgrounds[0].position -= new Vector3(movement.x * 10, movement.y * 5, 0);
        
        lastPlayerPos = Player.position;

        for (int i = 0; i <= 0; i++)
        {
            if (Backgrounds[i].position.x + 2f <= Player.position.x && Backgrounds.Count <= 1)
            {
                item = Backgrounds[i];
                ReadyToSpawn();

            }
            if (Backgrounds[i].position.x + 23f <= Player.position.x)
            {
                Backgrounds.Remove(item);
                Destroy(item.gameObject);
            }


        }
    }
    void ReadyToSpawn() {

        Transform t = Instantiate(BackgroundType);
        t.localPosition = new Vector2(Backgrounds[0].position.x + 35f, 0f);
        Backgrounds.Add(t);
        //Debug.Log(Backgrounds.Count);


    }

}




   