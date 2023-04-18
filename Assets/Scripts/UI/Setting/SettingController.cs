using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    public void ExitMenu()
    {
        MenuController.Instance.ClosePopup(Stage.SETTING);
    }
}
