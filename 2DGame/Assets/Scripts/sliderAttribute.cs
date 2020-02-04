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

    //the rings around each planet that display how intense the gravity is; they are set to inactive by default
    public GameObject ring1;
    public GameObject ring2;
    public GameObject ring3;
    public GameObject ring4;
    public GameObject ring5;


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

        DisplayRings(slider.value);
    }

    //displays rings based on the slider valie
    private void DisplayRings(float sliderValue) {

        if (sliderValue >= 0.8f)
        {
            ring1.SetActive(true);
            ring2.SetActive(true);
            ring3.SetActive(true);
            ring4.SetActive(true);
            ring5.SetActive(true);
        }
        else if (sliderValue >= 0.6f)
        {
            ring1.SetActive(true);
            ring2.SetActive(true);
            ring3.SetActive(true);
            ring4.SetActive(true);
            ring5.SetActive(false);
        }
        else if (sliderValue >= 0.4f)
        {
            ring1.SetActive(true);
            ring2.SetActive(true);
            ring3.SetActive(true);
            ring4.SetActive(false);
            ring5.SetActive(false);
        }
        else if (sliderValue >= 0.2f)
        {
            ring1.SetActive(true);
            ring2.SetActive(true);
            ring3.SetActive(false);
            ring4.SetActive(false);
            ring5.SetActive(false);
        }
        else if (sliderValue > 0f)
        {
            ring1.SetActive(true);
            ring2.SetActive(false);
            ring3.SetActive(false);
            ring4.SetActive(false);
            ring5.SetActive(false);
        }
        else {
            ring1.SetActive(false);
            ring2.SetActive(false);
            ring3.SetActive(false);
            ring4.SetActive(false);
            ring5.SetActive(false);
        }
    }
}
