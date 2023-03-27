using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuControler : MonoBehaviour
{
    private VisualElement root;
    private VisualElement header;
    private VisualElement body;
    private Button play;
    private Button setting;
    private Button shop;
    // Start is called before the first frame update
    private void Awake()
    {
        root = GameObject.FindGameObjectWithTag("MainMenu")
            .GetComponent<UIDocument>()
            .rootVisualElement;
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
    }

    private void SettingClicked(ClickEvent evt)
    {
        Debug.Log("Setting button clicked");
    }

    private void PlayClicked(ClickEvent e)
    {
        Debug.Log("Hello world");
    }

    // Update is called once per frame
}
