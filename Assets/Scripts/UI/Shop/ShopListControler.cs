using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopListControler : MonoBehaviour
{
    [SerializeField] Data dataList;
    [SerializeField] GameObject container;
    public void ItemChoice()
    {
        GameObject prefab = ShopController.Instance.GetItemPrefab(Type.ITEMS);

    }

    public void GoldChoice()
    {
        GameObject prefab = ShopController.Instance.GetItemPrefab(Type.ITEMS);
    }

    public void SkinChoice()
    {
        GameObject prefab = ShopController.Instance.GetItemPrefab(Type.ITEMS);
    }
}
[System.Serializable]
class Data
{
    public Sprite icon;
    public int level;
    public string price;
}
