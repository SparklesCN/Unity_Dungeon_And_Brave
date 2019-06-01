using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInitial : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
       
        PlayerPrefs.SetInt("HP", 100);
        PlayerPrefs.SetInt("MP", 100);
        PlayerPrefs.SetInt("EXP", 0);
        PlayerPrefs.SetInt("LV", 1);
        PlayerPrefs.SetInt("SceneNum", 1);
       
    }

}
