using FusionExamples.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<GameObject> list;
    
    public void UpdateLevel(int level)
    {
        
    }

    private void ResetShop()
    {
       foreach(GameObject levelList in list)
       {

       }
    }
}
