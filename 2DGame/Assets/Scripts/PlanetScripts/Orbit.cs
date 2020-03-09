using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //turns gravity back on for the other planets once orbitting is finished
        if (Database.isOrbiting == false)
        {
            Orbit[] Planets = FindObjectsOfType<Orbit>();
            foreach (Orbit Planet in Planets)
            {
                Planet.GetComponent<Attractor>().enabled = true;
            }
        }
    }
}
