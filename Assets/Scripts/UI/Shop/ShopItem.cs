using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    private string _uid;
    private string itemName;
    private int level;
    private string assetsPath;
    private int price;

    public ShopItem()
    {
        _uid = Guid.NewGuid().ToString();
    }

    public ShopItem(string itemName, int level, string assetsPath, int price): this()
    {
        this.itemName = itemName;
        this.level = level;
        this.assetsPath = assetsPath;
        this.price = price;
    }

    public ShopItem(string uid, string itemName, int level, string assetsPath, int price)
    {
        _uid = uid;
        this.itemName = itemName;
        this.level = level;
        this.assetsPath = assetsPath;
        this.price = price;
    }

    public string ItemName
    {
        get { return itemName; }
        set { this.itemName = value; }
    }
}
