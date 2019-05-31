using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControlor : MonoBehaviour
{
    public int nextScene, formerScene;
    private void Start()
    {
        PlayerPrefs.SetInt("HP", 100);
        PlayerPrefs.SetInt("MP", 100);
        PlayerPrefs.SetInt("EXP", 0);
        PlayerPrefs.SetInt("LV", 1);
        PlayerPrefs.SetInt("SceneNum", 1);
    }
}
