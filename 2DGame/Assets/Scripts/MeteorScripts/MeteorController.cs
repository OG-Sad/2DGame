using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorController : MonoBehaviour
{

    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //moves meteor to the left over time
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //rotate meteor
        //transform.Rotate(new Vector3(60, 0, -10) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            //do nothing for now
        }
        if (coll.gameObject.tag == "Player" && PowerUps.PlayerPoweredUp == true && PowerUps.ChoosePowerUp == 4)
        {

        }
        else if (coll.gameObject.tag == "Player")
        {
            Database.gameEnd = true;
        }
    }
   
}
