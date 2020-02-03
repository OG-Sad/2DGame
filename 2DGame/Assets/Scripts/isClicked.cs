// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class isClicked : MonoBehaviour
// {   
//     public GameObject planet;
//     public bool isDown = false;
//     // Start is called before the first frame update

//     // void OnMouseOver(){
//     //     Debug.Log("Over!");
//     //     if(Input.GetMouseDown(0) && isDown == false){
//     //         Debug.Log("Held!");
//     //         isDown = planet.GetComponent<changeGravity>().OnClick(isDown);
//     //     }
//     // }
//     void OnMouseDown() {
//         if (Input.GetMouseButtonDown(0) && isDown == false) {
//             Debug.Log("Held!");
//             isDown = planet.GetComponent<changeGravity>().OnClick(isDown);
//         }
//     }

//     void OnMouseUp() {
//         isDown = planet.GetComponent<changeGravity>().OnClickUp(isDown);
//     }
// }
