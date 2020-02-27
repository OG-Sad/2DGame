using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//need this line to tell unity that we will be saving this data in a file
[System.Serializable]
public class PlayerData
{
    //list of all power ups
    public List<ShopItem> buildingsList;

    public PlayerData(List<ShopItem> bList) {
        buildingsList = bList;
    }
}
