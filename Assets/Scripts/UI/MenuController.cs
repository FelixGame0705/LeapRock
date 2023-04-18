using FusionExamples.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : Singleton<MenuController>
{
    [SerializeField] private List<GameObject> menuList;


    public void UpdatePopup(Stage stage)
    {
        foreach (GameObject gameObject in menuList)
        {
            if(gameObject.GetComponent<StageMenu>().stageMenu == stage) gameObject.SetActive(true);
        }
    }

    public void ClosePopup(Stage stage)
    {
        foreach (GameObject gameObject in menuList)
        {
            if (gameObject.GetComponent<StageMenu>().stageMenu == stage) gameObject.SetActive(false);
        }
    }
}
