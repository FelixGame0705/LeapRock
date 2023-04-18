using Assets.Scripts.UI.MainMenu;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TreasureListContainer : MonoBehaviour
{
    public GameObject[] treasureList;
    private void Awake()
    {
        Init();
    }

    public void UpdateTreasureList(Queue<Treasure> treasureDataList)
    {
        foreach(GameObject go in treasureList)
        {
            var data = treasureDataList.Dequeue();
            go.GetComponent<Image>().sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>(data.IconPath);
            go.transform.GetChild(0).gameObject.GetComponent<Text>().text = data.Status.ToString();
            if(data.Status == true)
            {
                go.SetActive(true);
            }
        }
    }
    private void TreasureClicked(GameObject go)
    {
        var button = go.GetComponent<Button>();
        var text = go.GetComponent<Text>();
    }

    private void Clear()
    {
        foreach(GameObject treasureObject in treasureList)
        {
            var button = treasureObject.GetComponent<Button>();
            var status = treasureObject.transform.GetChild(0).GetComponent<Text>();
            status.text = "";
            treasureObject.SetActive(false);
        }
    }

    private void Init()
    {
        foreach(GameObject treasure in treasureList)
        {
            var button = treasure.GetComponent<Button>();
            var status = treasure.transform.GetChild(0).GetComponent<Text>();
            button.onClick.AddListener(()=>TreasureClicked(treasure));
            treasure.SetActive(false);
        }
    }
}
