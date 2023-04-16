using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Controler : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainMenu;
    private GameObject current;
    private GameObject root;
    private Stack<GameObject> uiForm;
    private void Awake()
    {
        root = GameObject.FindGameObjectWithTag("MainMenu");
        uiForm = new Stack<GameObject>();
        current = mainMenu;
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
            case Stage.MainMenu:
                GameObject mm = Resources.Load<GameObject>("");
                break;
            case Stage.Setting:
                GameObject setting = Resources.Load<GameObject>("");

                break;
            case Stage.InGame:
                GameObject ingame = Resources.Load<GameObject>("");
                break;
            case Stage.Shop:
                GameObject shop = Resources.Load<GameObject>("");
                break;

            case Stage.OpenChest:
                GameObject opChest = Resources.Load<GameObject>("");
                break;

            case Stage.None:
                GameObject none = Resources.Load<GameObject>("None");
                break;
        }
    }
}
