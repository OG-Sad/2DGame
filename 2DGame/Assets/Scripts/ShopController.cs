using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    private string currentTabSelect = "Power Ups";

    int currentStars;
    public Text stars;

    public Button powerUpsButton;
    public Button skinsButton;
    public Button backgroundsButton;

    public GameObject powerUps;
    public GameObject skins;
    public GameObject backgorunds;
    
    void Start()
    {
        currentStars = PlayerPrefs.GetInt("Stars");
        stars.text = currentStars.ToString();
        PowerUpsClicked();
    }

    void Update()
    {
        
    }

    public void PowerUpsClicked() {
        currentTabSelect = "Power Ups";

        powerUpsButton.GetComponent<Image>().color = new Color(183f / 255f, 183f / 255f, 183f / 255f);
        skinsButton.GetComponent<Image>().color = Color.white;
        backgroundsButton.GetComponent<Image>().color = Color.white;

        skins.SetActive(false);
        backgorunds.SetActive(false);
        powerUps.SetActive(true);
    }

    public void SkinsClicked()
    {
        currentTabSelect = "Skins";

        skinsButton.GetComponent<Image>().color = new Color(183f / 255f, 183f / 255f, 183f / 255f);
        powerUpsButton.GetComponent<Image>().color = Color.white;
        backgroundsButton.GetComponent<Image>().color = Color.white;

        powerUps.SetActive(false);
        backgorunds.SetActive(false);
        skins.SetActive(true);
    }

    public void BackgroundClicked()
    {
        currentTabSelect = "Skins";

        backgroundsButton.GetComponent<Image>().color = new Color(183f / 255f, 183f / 255f, 183f / 255f);
        skinsButton.GetComponent<Image>().color = Color.white;
        powerUpsButton.GetComponent<Image>().color = Color.white;

        skins.SetActive(false);
        powerUps.SetActive(false);
        backgorunds.SetActive(true);
    }

    public void PowerUpInvincibility() {
        if (currentStars >= 10) {
            PlayerPrefs.SetInt("stars", currentStars - 10);
            stars.text = PlayerPrefs.GetInt("stars").ToString();
            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/Invincibility/Cost");
            costText.GetComponent<Text>().text = "Owned";
        }
    }
}
