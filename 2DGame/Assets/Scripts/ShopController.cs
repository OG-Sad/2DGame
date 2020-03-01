using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    //list of all power ups
    List<ShopItem> itemList = new List<ShopItem>() {
        new ShopItem(){ name = "Invincibility", cost = 10, owned = false},
        new ShopItem(){ name = "Boost", cost = 10, owned = false},
        new ShopItem(){ name = "Time", cost = 10, owned = false},
        new ShopItem(){ name = "Magnet", cost = 10, owned = false}
    };

    void Start()
    {
        itemList = SaveSystem.LoadPlayer().itemList;

        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].owned == true)
            {
                string itemName = itemList[i].name;
                GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
                costText.GetComponent<Text>().text = "Owned";
            }
        }

        currentStars = PlayerPrefs.GetInt("Stars");
        stars.text = currentStars.ToString();
        PowerUpsClicked();
    }

    void Update()
    {

    }

    //saves the shop data when the game closes
    private void OnApplicationQuit()
    { 
        SaveSystem.SavePlayer(itemList);
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

    public void BuyShopItem() {


        //gets the name of the button that was clicked
        string itemName = EventSystem.current.currentSelectedGameObject.name;
        bool itemOwned = false;

        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].name == itemName)
            {
                itemOwned = itemList[i].owned;
            }
        }

        if (currentStars != 10 && itemOwned == false) {

            PlayerPrefs.SetInt("stars", currentStars - 10);
            stars.text = PlayerPrefs.GetInt("stars").ToString();

            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            costText.GetComponent<Text>().text = "Owned";

            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].name == itemName)
                {
                    itemList[i].owned = true;
                }
            }
        }
    }

    public void ResetData()
    {
        itemList = new List<ShopItem>() {
            new ShopItem(){ name = "Invincibility", cost = 10, owned = false},
            new ShopItem(){ name = "Boost", cost = 10, owned = false},
            new ShopItem(){ name = "Time", cost = 10, owned = false},
            new ShopItem(){ name = "Magnet", cost = 10, owned = false}
        };

        //redraws all of the items
        for (int i = 0; i < itemList.Count; i++)
        {
            string itemName = itemList[i].name;
            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            costText.GetComponent<Text>().text = "10";
        }
    }

    //goes back to main menu
    public void MainMenu() {
        SaveSystem.SavePlayer(itemList);
        SceneManager.LoadScene("MenuScene");
    }
}
