using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuControler : MonoBehaviour
{
    private string tresureItem = "";
    private VisualElement root;
    private VisualElement header;
    private VisualElement body;
    private VisualElement treasureList; //Max capacity is 4
    private int MAXLIST = 4;
    private Button play;
    private Button setting;
    private Button shop;
    // Start is called before the first frame update
    private void Awake()
    {
        root = GameObject.FindGameObjectWithTag("MainMenu")
            .GetComponent<UIDocument>()
            .rootVisualElement;
        Debug.Log(root.Q<VisualElement>("savearea").ToString());
        header = root.Q<TemplateContainer>("HeaderMenu");
        body = root.Q<TemplateContainer>("BodyMenu");
        play = body.Q<Button>(name:"play_btn");
        play.RegisterCallback<ClickEvent>(PlayClicked);
        setting = header.Q<Button>(name: "setting_btn");
        setting.RegisterCallback<ClickEvent>(SettingClicked);
        shop = body.Q<Button>(name: "shop_btn");
        shop.RegisterCallback<ClickEvent>(ShopClicked);
    }

    private void ShopClicked(ClickEvent evt)
    {
        Debug.Log("Shop Button Clicked");
        var temp = root.Q<VisualElement>("savearea");
        double h = temp.resolvedStyle.height;
        double w = temp.resolvedStyle.width;
        Debug.Log("width = " + w + " " + "height=" + h);
    }

    private void SettingClicked(ClickEvent evt)
    {
        Debug.Log("Setting button clicked");
    }

    private void PlayClicked(ClickEvent e)
    {
        Debug.Log("Hello world");
    }

    private VisualElement getItem(string path)
    {
        VisualElement item;
        item = Resources.Load<VisualTreeAsset>(path).CloneTree().Q<VisualElement>("container");
        return item;
    }

    private void updateTreasureList(Stack<VisualElement> activeTreasure)
    {
        
    }

    // Update is called once per frame
}
