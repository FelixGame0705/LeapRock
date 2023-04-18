using FusionExamples.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<GameObject> list;
    
    public void UpdateLevel(int level)
    {
        ResetLevel();
        int levelcount = 1;
        foreach (GameObject levelEntity in list)
        {
            var imageEntity = levelEntity.GetComponent<Image>();
            imageEntity.color = Color.yellow;
            if(levelco)
        }
    }

    private void ResetLevel()
    {
       foreach(GameObject levelEntity in list)
       {
            var imageEntity = levelEntity.GetComponent<Image>();
            imageEntity.color = Color.gray;
       }
    }
}
