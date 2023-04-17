using Assets.Scripts.UI.MainMenu;
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
    private AppData appData;
    private CurrencyDisplay currencyDisplay;
    private TreasureListContainer treasureContainer;
    private ScoreDisplay scoreDisplay;
    private void Awake()
    {
        setting_btn = GameObject.Find("Setting").GetComponent<Button>();
        shop_btn = GameObject.Find("Shop").GetComponent<Button>();
        play_btn = GameObject.Find("Play").GetComponent<Button>();
        shop_btn.onClick.AddListener(ShopClicked);
        play_btn.onClick.AddListener(PlayClicked);
        setting_btn.onClick.AddListener(SettingClicked);
        controler = GameObject.Find("Controler").GetComponent<Controler>();
        currencyDisplay = GameObject.Find("CurrencyGroup").GetComponent<CurrencyDisplay>();
        currencyDisplay.UpdateUI(appData.PlayerInfo.Money, appData.PlayerInfo.Diamond);
        var bottom = this.transform.Find("Bottom").gameObject.transform.Find("TreasureListContainer").gameObject;
        treasureContainer = GameObject.Find("TreasureListContainer").GetComponent<TreasureListContainer>();
        treasureContainer.UpdateTreasureList(new Queue<Treasure>(appData.TreasureList));
        scoreDisplay = GameObject.Find("Score").GetComponent<ScoreDisplay>();
    }
    public void UpdateUI()
    {
        currencyDisplay.UpdateUI(appData.PlayerInfo.Money, appData.PlayerInfo.Diamond);
        treasureContainer.UpdateTreasureList(new Queue<Treasure>(appData.TreasureList));
        scoreDisplay.UpdateScore(appData.PlayerInfo.HighScore);
    }
    public AppData AppData
    {
        get { return appData; }
        set { appData = value; }
    }
    private void SettingClicked()
    {
        controler.LoadUI(Stage.SETTING);
    }

    private void PlayClicked()
    {
        controler.LoadUI(Stage.INGAME);
    }
    private void ShopClicked()
    {
        controler.LoadUI(Stage.SHOP);
    }
}
