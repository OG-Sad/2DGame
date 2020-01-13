using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderAttribute : MonoBehaviour
{
    public bool visible = false;
    Rigidbody2D PlanetRB;
    // Gets the slider and which planet
    public Slider slider;
    public GameObject planet;

    // Get Sprite Render and Canvas Group components
    SpriteRenderer m_SpriteRenderer;
    CanvasGroup m_alpha;

    // The Color to be assigned to the Renderer's Material
    Color m_NewColor;


    void Start()
    {
        PlanetRB = GetComponent<Rigidbody2D>();
        // Fetch the SpriteRenderer from the Circle
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // Fetch the CanvasGroup from the Slider and sets Alpha to 0
        m_alpha = slider.GetComponent<CanvasGroup>();
        if (visible == false) {
            m_alpha.alpha = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Updates m_NewColor when slider is moved and changes the color of m_SpriteRenderer
        // Red if gameObject name is "bigPlanet(Clone)" and green if it is "smallPlanet(Clone)"
        if (planet.name == "bigPlanet(Clone)") {
            m_NewColor = new Color(slider.value, 0, 0);
            PlanetRB.mass = slider.value * 100;
        }

        

        else {
            m_NewColor = new Color(0, slider.value, 0);
            PlanetRB.mass = slider.value * 50;
            // Debug.Log(planet.name);
        }
        m_SpriteRenderer.color = m_NewColor;
        //Debug.Log(m_NewColor);
    }   
}
