using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControlor : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("HP", 100);
        PlayerPrefs.SetInt("MP", 100);
        PlayerPrefs.SetInt("EXP", 0);
        PlayerPrefs.SetInt("LV", 1);
        PlayerPrefs.SetInt("SceneNum", 1);
    }
}
