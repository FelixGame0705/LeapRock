using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameObject scoreObject;
    private Text scoreText;
    private void Awake()
    {
        scoreText = scoreObject.GetComponent<Text>();
        Clear();
    }

    public void Clear()
    {
        scoreText.text = "0000";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
