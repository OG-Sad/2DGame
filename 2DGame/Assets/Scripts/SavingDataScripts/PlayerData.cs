using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//need this line to tell unity that we will be saving this data in a file
[System.Serializable]
public class PlayerData
{
    //list of all power ups
    public Dictionary<string, ShopItem> itemList;

    public PlayerData(Dictionary<string, ShopItem> iList) {
        itemList = iList;
    }
}
