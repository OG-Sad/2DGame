using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public static bool  resetGo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
