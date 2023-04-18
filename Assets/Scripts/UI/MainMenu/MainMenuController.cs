using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SettingsGame()
    {
        MenuController.Instance.UpdatePopup(Stage.SETTING);
    }
    public void ShopGame()
    {
        MenuController.Instance.UpdatePopup(Stage.SHOP);
    }
}
