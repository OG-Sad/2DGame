using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static bool reset = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);
            reset = true;
        }

        else
        {
           // Destroy(other.gameObject);
                reset = true;
        }
        
    }
}
