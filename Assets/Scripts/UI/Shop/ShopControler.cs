using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Assets.Scripts.UI.Shop;
using System.Runtime.CompilerServices;
using Assets.Scripts;
using Assets.Scripts.UI;

public class ShopControler : MonoBehaviour
{
    private VisualElement root;
    private Button item_btn;
    private Button skin_btn;
    private Button gold_btn;
    private Queue<VisualElement> item_item;
    private Queue<VisualElement> skin_item;
    private Queue<VisualElement> gold_item;
    private ScrollView list;
    private DataReader<ItemsModel> dataReader;
    public VisualTreeAsset shop_Doc;
    private ScaleCaculator scale;
    private VisualElement shop;
    public VisualTreeAsset item_template;
    private bool scale_check = false;
    private void Awake()
    {
        scale = new ScaleCaculator();
        root = GameObject.FindGameObjectWithTag("MainMenu")
            .GetComponent<UIDocument>()
            .rootVisualElement.Q<VisualElement>("savearea");
        clearUIDocument();
        shop = shop_Doc.CloneTree();
        root.Add(shop);
        item_btn = shop.Q<Button>(name: "item_btn");
        skin_btn = shop.Q<Button>(name: "skin_btn");
        gold_btn = shop.Q<Button>(name: "gold_btn");
        item_btn.RegisterCallback<ClickEvent>(itemClicked);
        skin_btn.RegisterCallback<ClickEvent>(skinClicked);
        gold_btn.RegisterCallback<ClickEvent>(goldClicked);
        dataReader = new DataReader<ItemsModel>();
        list = root.Q<ScrollView>("item_list");
        VisualElement entity = item_template.CloneTree().Q<VisualElement>("item_container");
        list.Add(entity);
        StartCoroutine(GetSize());
    }

    private VisualElement MakeItem()
    {
        VisualElement entity = item_template.CloneTree().Q<VisualElement>("item_container");
        return entity;
    }

    private IEnumerator GetSize()
    {
        yield return new WaitForEndOfFrame();
        SizeStruct rootSize = new SizeStruct();
        SizeStruct shopSize = new SizeStruct(); 
        rootSize.width = root.resolvedStyle.width - root.resolvedStyle.marginLeft - root.resolvedStyle.marginRight;
        rootSize.height = root.resolvedStyle.height - root.resolvedStyle.marginTop - root.resolvedStyle.marginBottom;
        shopSize.width = shop.resolvedStyle.width;
        shopSize.height = shop.resolvedStyle.height;
        ScaleCaculator scaleCaculator = new ScaleCaculator();
        scaleCaculator.setScale(rootSize, shopSize);
        shop.transform.scale = new Vector3(scaleCaculator.ScaleX, scaleCaculator.ScaleY,0f);
    }

    private Queue<ItemsModel> getData()
    {
        Queue<ItemsModel> temp = dataReader.loadFromJSON("itemdata.json");
        return temp;
    }

    private void clearUIDocument()
    {
        root.Clear();
    }

    private void updateItemList()
    {
        item_item.Clear();
        Queue<ItemsModel> data = getData();
        while(data.Count > 0)
        {
            var temp = data.Dequeue();
            VisualElement entity = item_template.CloneTree().Q<VisualElement>("item_container");
            var icon = entity.Q<VisualElement>("icon");
            var price = entity.Q<Label>("prize");
            price.text = price.ToString();
            icon.style.backgroundImage = Resources.Load<Texture2D>(temp.IconPath);
            item_item.Enqueue(entity);
        }

    }
    private void updateSkinList()
    {
        skin_item.Clear();
        var item_template = Resources.Load<VisualTreeAsset>("");
        Queue<ItemsModel> data = getData();
        while(data.Count > 0)
        {
            var temp = data.Dequeue();
            VisualElement entity = item_template.CloneTree().Q<VisualElement>("container");

        }
    }
    private void itemClicked(ClickEvent e)
    {
        list.Clear();
        updateItemList();
        while(item_item.Count > 0)
        {
            list.Add(item_item.Dequeue());
        } 
    }
    private void skinClicked(ClickEvent e)
    {
        list.Clear();

    }

    private void goldClicked(ClickEvent e)
    { 
        double h = root.resolvedStyle.height;
        double w = root.resolvedStyle.width;
        Debug.Log("width = " + w + " " + "height=" + h);
    }

}
