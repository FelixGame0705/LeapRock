using FusionExamples.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : Singleton<ShopController>
{
    [SerializeField] List<GameObject> itemPrefabList;

    // Start is called before the first frame update
    public void Exit()
    {
        MenuController.Instance.ClosePopup(Stage.SHOP);
    }

    public GameObject GetItemPrefab(Type type)
    {
        foreach(var item in itemPrefabList)
        {
            if(item.GetComponent<ItemType>().itemType == type)
            {
                return item;
            }
        }
        return null;
    }
}
