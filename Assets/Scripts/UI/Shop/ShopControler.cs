using Assets.Scripts;
using Assets.Scripts.UI.MainMenu;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ShopControler : MonoBehaviour
{
    private ListViewControler listControler;
    private Button backMenu;
    private Button item_btn;
    private Button skin_btn;
    private Button gold_btn;
    private AppData programData;
    private DataType form;
    private Queue<GameObject> item_list = new Queue<GameObject>();
    [SerializeField] private GameObject listObject;
    // Start is called before the first frame update
    private void Awake()
    { 
        form = new DataType();
        listControler = listObject.GetComponent<ListViewControler>();
        item_btn.onClick.AddListener(ItemClicked);
        skin_btn.onClick.AddListener(SkinClicked);
        gold_btn.onClick.AddListener(GoldClicked);
    }

    private void ItemClicked()
    {
        listControler.Clear();
        
    }

    private void SkinClicked()
    {
        listControler.Clear();
    }

    private void GoldClicked() {
        listControler.Clear();
    }

    public AppData ProgramData
    {
        get { return programData; }
        set { programData = value; }
    }
}

enum DataType
{
    ITEM,
    SKIN,
    GOLD
}
