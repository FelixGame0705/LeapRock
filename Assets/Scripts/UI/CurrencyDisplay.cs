using Assets.Scripts.UI.MainMenu;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{

    [SerializeField] private GameObject diamondObject;
    [SerializeField] private GameObject goldObject;
    private Text diamondDisplay;
    private Text goldDisplay;
    // Start is called before the first frame update
    void Awake()
    {
       diamondDisplay = diamondObject.GetComponent<Text>();
       goldDisplay = goldObject.GetComponent<Text>();
       clearUI();
    }

    public void clearUI()
    {
        diamondDisplay.text = "0000";
        goldDisplay.text = "0000";
    }
    // Update is called once per frame
    public void UpdateUI(int gold, int diamond)
    {
        clearUI();
        diamondDisplay.text = diamond.ToString();
        goldDisplay.text = gold.ToString(); 
    }
}
