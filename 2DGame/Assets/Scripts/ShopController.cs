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

    //list of all power ups; itemList gets set back to this when data is reset
    List<ShopItem> itemList = new List<ShopItem>() {
        new ShopItem(){ name = "Invincibility", cost = 30, upgradeLevel = 1},
        new ShopItem(){ name = "Boost", cost = 30, upgradeLevel = 1},
        new ShopItem(){ name = "Time", cost = 30, upgradeLevel = 1},
        new ShopItem(){ name = "Magnet", cost = 30, upgradeLevel = 1}
    };

    //dictionary of costs of an item based on its upgrade level
    Dictionary<int, int> costDict = new Dictionary<int, int>() {
        {1,30},
        {2,50},
        {3,100},
        {4,250}
    };

    void Start()
    {
        //will load a save file if there is one
        try
        {
            itemList = SaveSystem.LoadPlayer().itemList;
        }
        //if there's an error, the item list will just be the default base item list
        catch (System.Exception ex)
        {
            print("No save file found");
        }

        //loads the correct texts into the cost section of each item
        for (int i = 0; i < itemList.Count; i++) {
            string itemName = itemList[i].name;
            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            costText.GetComponent<Text>().text = costDict[itemList[i].upgradeLevel].ToString();
        }

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
        int itemCost = 0;
        int itemUpgradeLevel = 0;
        int newItemCost = 0;

        //finds whether or not the item is currently owned and the cost of the item
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].name == itemName)
            {
                itemCost = costDict[itemList[i].upgradeLevel];
                itemUpgradeLevel = itemList[i].upgradeLevel;
            }
        }

        if (currentStars >= itemCost && itemUpgradeLevel < 5) {

            //sets the item's "owned" bool to true
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].name == itemName)
                {
                    itemList[i].upgradeLevel++;
                    newItemCost = costDict[itemList[i].upgradeLevel];
                }
            }

            currentStars -= itemCost;
            PlayerPrefs.SetInt("Stars", currentStars);
            stars.text = PlayerPrefs.GetInt("Stars").ToString();

            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            costText.GetComponent<Text>().text = newItemCost.ToString();
        }
    }

    //resets all item ownership data
    public void ResetData()
    {
        //redraws all of the items
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].upgradeLevel = 1;

            string itemName = itemList[i].name;
            GameObject costText = GameObject.Find("Canvas/Panel/Power Ups/" + itemName + "/Cost");
            costText.GetComponent<Text>().text = costDict[itemList[i].upgradeLevel].ToString();
        }
    }

    //goes back to main menu
    public void MainMenu() {
        SaveSystem.SavePlayer(itemList);
        SceneManager.LoadScene("MenuScene");
    }
}
