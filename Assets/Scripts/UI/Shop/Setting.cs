using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    private float musicVolume;
    private float totalVolume;
    private int language; // 0 is english, 1 is vietnamese

    public Setting()
    {
        musicVolume = 0;
        totalVolume = 0;
        language = 0;
    }
    public Setting(float musicVolume, float totalVolume, int lang)
    {
        this.musicVolume = musicVolume;
        this.totalVolume = totalVolume;
        this.language = lang;
    }
    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }

    public float TotalVolume
    {
        get { return totalVolume; }
        set { totalVolume = value; }
    }

    public int Language
    {
        get { return language; }
        set { language = value; }
    }
}
