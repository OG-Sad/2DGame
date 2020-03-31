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
        bool isOrbitTrue = false;

        Orbit[] Planets = FindObjectsOfType<Orbit>();
        foreach (Orbit Planet in Planets)
        {
            if(Planet.GetComponent<Attractor>().isOrbiting) {
                isOrbitTrue = true;
            }
        }
        
        Database.isOrbiting = isOrbitTrue ? true : false;

        Debug.Log(Database.isOrbiting);
    }
}
