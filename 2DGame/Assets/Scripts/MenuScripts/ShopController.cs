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

    //dictionary of all power ups; itemList gets set back to this when data is reset
    Dictionary<string, ShopItem> itemList = new Dictionary<string, ShopItem>() {
        {"Invincibility", new ShopItem(){ name = "Invincibility", cost = 30, upgradeLevel = 1}},
        {"Boost", new ShopItem(){ name = "Boost", cost = 30, upgradeLevel = 1}},
        {"Time", new ShopItem(){ name = "Time", cost = 30, upgradeLevel = 1}},
        {"Magnet", new ShopItem(){ name = "Magnet", cost = 30, upgradeLevel = 1}}
    };

    //dictionary of costs of an item based on its upgrade level
    Dictionary<int, int> costDict = new Dictionary<int, int>() {
        {1,30},
        {2,50},
        {3,100},
        {4,250},
        //there isn't meant to be a cost when an item is at level 5
        {5, 0}
    };

    void Start()
    {
        DisplayInitData();

        //get rid of this later
        PlayerPrefs.SetInt("Stars", 99999999);
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

    //fetches a save file and displays the data in the file
    void DisplayInitData() {
        //will load a save file if there is one
        try
        {
            if (SaveSystem.LoadPlayer().itemList != null) {
                itemList = SaveSystem.LoadPlayer().itemList;
            }
        }
        //if there's an error, the item list will just be the default base item list
        catch (System.Exception ex)
        {
            print("No save file found");
        }

        //loads the correct texts into the cost section of each item
        foreach (string key in itemList.Keys)
        {
            string itemName = itemList[key].name;

            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            if (itemList[key].upgradeLevel < 5)
            {
                costText.GetComponent<Text>().text = costDict[itemList[key].upgradeLevel].ToString();
            }
            else
            {
                costText.GetComponent<Text>().text = "Max Level";
            }

            GameObject bar1 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 1");
            GameObject bar2 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 2");
            GameObject bar3 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 3");
            GameObject bar4 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 4");
            GameObject bar5 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 5");

            if (itemList[key].upgradeLevel == 1)
            {
                bar1.GetComponent<Image>().color = new Color(0, 224, 213);
            }
            else if (itemList[key].upgradeLevel == 2)
            {
                bar1.GetComponent<Image>().color = new Color(0, 224, 213);
                bar2.GetComponent<Image>().color = new Color(0, 224, 213);
            }
            else if (itemList[key].upgradeLevel == 3)
            {
                bar1.GetComponent<Image>().color = new Color(0, 224, 213);
                bar2.GetComponent<Image>().color = new Color(0, 224, 213);
                bar3.GetComponent<Image>().color = new Color(0, 224, 213);
            }
            else if (itemList[key].upgradeLevel == 4)
            {
                bar1.GetComponent<Image>().color = new Color(0, 224, 213);
                bar2.GetComponent<Image>().color = new Color(0, 224, 213);
                bar3.GetComponent<Image>().color = new Color(0, 224, 213);
                bar4.GetComponent<Image>().color = new Color(0, 224, 213);
            }
            else if (itemList[key].upgradeLevel == 5)
            {
                bar1.GetComponent<Image>().color = new Color(0, 224, 213);
                bar2.GetComponent<Image>().color = new Color(0, 224, 213);
                bar3.GetComponent<Image>().color = new Color(0, 224, 213);
                bar4.GetComponent<Image>().color = new Color(0, 224, 213);
                bar5.GetComponent<Image>().color = new Color(0, 224, 213);
            }
        }
    }

    //switches to the power ups tab
    public void PowerUpsClicked() {
        currentTabSelect = "Power Ups";

        powerUpsButton.GetComponent<Image>().color = new Color(183f / 255f, 183f / 255f, 183f / 255f);
        skinsButton.GetComponent<Image>().color = Color.white;
        backgroundsButton.GetComponent<Image>().color = Color.white;

        skins.SetActive(false);
        backgorunds.SetActive(false);
        powerUps.SetActive(true);
    }

    //switches to the skins tab
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

    //switches to the backgrounds tab
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

    //buys a shop item
    public void BuyShopItem() {

        //gets the name of the button that was clicked
        string itemName = EventSystem.current.currentSelectedGameObject.name;
        int itemCost = 0;
        int itemUpgradeLevel = 0;
        int newItemCost = 0;

        itemCost = costDict[itemList[itemName].upgradeLevel];
        itemUpgradeLevel = itemList[itemName].upgradeLevel;

        if (currentStars >= itemCost && itemUpgradeLevel < 5) {

            //adds 1 to the upgrade level
            itemList[itemName].upgradeLevel++;
            //gets new item upgrade level
            itemUpgradeLevel = itemList[itemName].upgradeLevel;
            newItemCost = costDict[itemUpgradeLevel];

            currentStars -= itemCost;
            PlayerPrefs.SetInt("Stars", currentStars);
            stars.text = PlayerPrefs.GetInt("Stars").ToString();

            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            if (itemUpgradeLevel < 5)
            {
                costText.GetComponent<Text>().text = newItemCost.ToString();
            }
            else {
                costText.GetComponent<Text>().text = "Max Level";
            }

            UpdateUpgradeMeter(itemName, itemUpgradeLevel);
        }
    }

    //updates an item's upgradeMeter bar's color
    void UpdateUpgradeMeter(string itemName, int upgradeLevel) {
        GameObject bar1 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 1");
        GameObject bar2 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 2");
        GameObject bar3 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 3");
        GameObject bar4 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 4");
        GameObject bar5 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 5");

        if (upgradeLevel == 1)
        {
            bar1.GetComponent<Image>().color = new Color(0, 224, 213);
        }
        else if (upgradeLevel == 2)
        {
            bar1.GetComponent<Image>().color = new Color(0, 224, 213);
            bar2.GetComponent<Image>().color = new Color(0, 224, 213);
        }
        else if (upgradeLevel == 3)
        {
            bar1.GetComponent<Image>().color = new Color(0, 224, 213);
            bar2.GetComponent<Image>().color = new Color(0, 224, 213);
            bar3.GetComponent<Image>().color = new Color(0, 224, 213);
        }
        else if (upgradeLevel == 4)
        {
            bar1.GetComponent<Image>().color = new Color(0, 224, 213);
            bar2.GetComponent<Image>().color = new Color(0, 224, 213);
            bar3.GetComponent<Image>().color = new Color(0, 224, 213);
            bar4.GetComponent<Image>().color = new Color(0, 224, 213);
        }
        else if (upgradeLevel == 5)
        {
            bar1.GetComponent<Image>().color = new Color(0, 224, 213);
            bar2.GetComponent<Image>().color = new Color(0, 224, 213);
            bar3.GetComponent<Image>().color = new Color(0, 224, 213);
            bar4.GetComponent<Image>().color = new Color(0, 224, 213);
            bar5.GetComponent<Image>().color = new Color(0, 224, 213);
        }
    }

    //resets all item ownership data
    public void ResetData()
    {
        //redraws all of the items
        foreach (string key in itemList.Keys)
        {
            itemList[key].upgradeLevel = 1;

            string itemName = itemList[key].name;
            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            costText.GetComponent<Text>().text = costDict[itemList[key].upgradeLevel].ToString();

            GameObject bar1 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 1");
            GameObject bar2 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 2");
            GameObject bar3 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 3");
            GameObject bar4 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 4");
            GameObject bar5 = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Upgrade Meter/Bar 5");

            //the first bar always has a color
            bar2.GetComponent<Image>().color = new Color(255, 255, 255);
            bar3.GetComponent<Image>().color = new Color(255, 255, 255);
            bar4.GetComponent<Image>().color = new Color(255, 255, 255);
            bar5.GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }

    //goes back to main menu
    public void MainMenu() {
        SaveSystem.SavePlayer(itemList);
        SceneManager.LoadScene("MenuScene");
    }
}
