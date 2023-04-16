using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuControler : MonoBehaviour
{
    private Button setting_btn;
    private Button shop_btn;
    private Button play_btn;
    private Controler controler;
    // Start is called before the first frame update
    void Start()
    {
        setting_btn = GameObject.Find("Setting").GetComponent<Button>();
        shop_btn = GameObject.Find("Shop").GetComponent<Button>();
        play_btn = GameObject.Find("Play").GetComponent<Button>();
        shop_btn.onClick.AddListener(ShopClicked);
        play_btn.onClick.AddListener(PlayClicked);
        setting_btn.onClick.AddListener(SettingClicked);
        controler = GameObject.Find("Controler").GetComponent<Controler>();
    }
    private void SettingClicked()
    {
        controler.LoadUI(Stage.Setting);
    }

    private void PlayClicked()
    {
        controler.LoadUI(Stage.InGame);
    }
    private void ShopClicked()
    {
        controler.LoadUI(Stage.Shop);
    }
}
