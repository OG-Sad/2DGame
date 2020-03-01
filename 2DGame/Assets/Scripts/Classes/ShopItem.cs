using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public string name { get; set; }
    public int cost { get; set; }
    public bool owned { get; set; }
}
