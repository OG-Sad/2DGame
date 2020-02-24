using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        //FadeOutAndIn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerable FadeOut() {
        for (float f = 1f; f >= -0.05f; f -= 0.05f) {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerable FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void FadeOutAndIn() {
        FadeOut();
        FadeOutAndIn();
        print("fsdf");
    }
}
