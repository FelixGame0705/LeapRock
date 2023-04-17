using Assets.Scripts;
using Assets.Scripts.UI.MainMenu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Controler : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainMenu;
    private GameObject current;
    private GameObject root;
    private Stack<GameObject> uiForm;
    private AppData appData;
    private Stage stage;
    private string prefabPath = "Assets/Prefabs/UI";
    private void Awake()
    {
        root = GameObject.FindGameObjectWithTag("MainMenu");
        uiForm = new Stack<GameObject>();
        LoadFromJSON();
        LoadUI(Stage.MAINMENU);
    }

    public void SwitchUI(GameObject newUI)
    {
        current.SetActive(false);
        current.transform.parent = null;
        uiForm.Push(current);
        newUI.transform.parent = root.transform;
        newUI.SetActive(true);
    }

    public void BackUI()
    {
        if(current != mainMenu)
        {
            current.SetActive(false);
            current.transform.parent = null;
            current = uiForm.Pop();
            current.transform.parent = root.transform;
            current.SetActive(true);
        }
        else
        {
            Application.Quit();
        }
        
    }

    public void LoadUI(Stage stage)
    {
        switch(stage)
        {
            case Stage.MAINMENU:
                if (!IsExisted("MainMenu"))
                {
                    GameObject mm = AssetDatabase.LoadAssetAtPath(prefabPath + "/Main Menu.prefab", typeof(UnityEngine.Object)) as GameObject;
                    current = GameObject.Instantiate(mm);
                    current.transform.parent = root.transform;
                    current.GetComponent<MainMenuControler>().AppData = appData;
                    SetAnchor(current);
                }
                else
                {
                    BackUI();
                    current.GetComponent<MainMenuControler>().UpdateUI();
                }

                this.stage = Stage.MAINMENU;
                break;
            case Stage.SETTING:
                GameObject setting = AssetDatabase.LoadAssetAtPath(prefabPath+"/Setting.prefab", typeof(UnityEngine.Object)) as GameObject;
                SwitchUI(setting);
                this.stage = Stage.SETTING;
                break;
            case Stage.INGAME:
                GameObject ingame = AssetDatabase.LoadAssetAtPath(prefabPath + "/Setting.prefab", typeof(UnityEngine.Object)) as GameObject;
                SwitchUI(ingame);
                this.stage = Stage.INGAME;
                break;
            case Stage.SHOP:
                GameObject shop = AssetDatabase.LoadAssetAtPath(prefabPath + "/Setting.prefab", typeof(UnityEngine.Object)) as GameObject;
                shop.GetComponent<ShopControler>().ProgramData = appData;
                SwitchUI(shop);
                this.stage = Stage.SHOP;
                break;

            case Stage.GACHA:
                GameObject opChest = AssetDatabase.LoadAssetAtPath(prefabPath + "/Setting.prefab", typeof(UnityEngine.Object)) as GameObject;
                this.stage = Stage.GACHA;
                break;
        }
    }

    public void LoadFromJSON()
    {
        DataReader<AppData> reader  = new DataReader<AppData>();
        appData = reader.loadFromJSON("appdata");
    }

    public void LoadToJSON()
    {
        DataReader<AppData> writer = new DataReader<AppData>();
    }

    private bool IsExisted(string name)
    {
        List<GameObject> temp = uiForm.ToList();
        foreach (GameObject go in temp)
        {
            if (go.name.Equals(name)) return true;
        }
        return false;
    }

    private void SetAnchor(GameObject go)
    {
        RectTransform temp =  go.GetComponent<RectTransform>();
        temp.offsetMin = new Vector2 (0, 0);
        temp.offsetMax = new Vector2(0, 0);
    }
}
