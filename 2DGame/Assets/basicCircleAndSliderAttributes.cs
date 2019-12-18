using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basicCircleAndSliderAttributes : MonoBehaviour
{

    // Position for slider and circle, plus the scaler
    public float xPosition = 0;
    public float yPosition = 0;
    public float scaler = 39.3f;

    // Gets the slider
    public Slider slider;

    // Get Sprite Render and Canvas Group components
    SpriteRenderer m_SpriteRenderer;
    CanvasGroup m_alpha;

    // The Color to be assigned to the Renderer's Material
    Color m_NewColor;


    void Start()
    {
        // Fetch the SpriteRenderer from the Circle
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // Fetch the CanvasGroup from the Slider and sets Alpha to 0
        m_alpha = slider.GetComponent<CanvasGroup>();
        m_alpha.alpha = 0;
    }


    // Update is called once per frame
    void Update()
    {
        // Updates m_NewColor when slider is moved and changes the color of m_SpriteRenderer
        m_NewColor = new Color(0.5f-slider.value, 0, 0);
        m_SpriteRenderer.color = m_NewColor;

        // Updates the position of the slider and circle
        slider.transform.localPosition = new Vector3(xPosition, yPosition, 0.0f);
        transform.position = new Vector3(xPosition/scaler, yPosition/scaler, 0.0f);
    }   
}
