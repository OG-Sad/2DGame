using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public static bool  resetGo = false;

    // Update is called once per frame
    void Update()
    {
        if (TargetController.reset == true)
        {
            Debug.Log("in");
            Destroy(gameObject);
            TargetController.reset = false;
            resetGo = true;
            
        }
    }
}
