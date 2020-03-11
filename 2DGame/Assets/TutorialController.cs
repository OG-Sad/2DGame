using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject player;
    GameObject Clone;
    // Start is called before the first frame update
    void Start()
    {
        Clone = player;
        Instantiate(Clone);
    }

    // Update is called once per frame
    void Update()
    {
        if(Reset.resetGo == true)
        {
           
            Instantiate(Clone);
            Reset.resetGo = false;
        }
    }
}
