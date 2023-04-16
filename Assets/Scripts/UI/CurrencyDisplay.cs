using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{

    [SerializeField] private Text displayUI;
    // Start is called before the first frame update
    void Start()
    {
       displayUI = GetComponent<Text>();
       clearUI();
    }

    public void clearUI()
    {
        displayUI.text = "0000";
    }
    // Update is called once per frame
    public void updateTextUI(int price)
    {
        double temp = price / 10000.0;
        if( temp > 1)
        {
            displayUI.text = temp.ToString() + "N$";
        }
    }
}
