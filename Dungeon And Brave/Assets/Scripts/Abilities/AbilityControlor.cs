using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityControlor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerPrefs.GetInt("LV");
        if (level > 1) 
        {
            // unlock spell_1
            GameObject.FindWithTag("Player").GetComponent<Player_Ability_1>().enabled = true;
            GameObject.Find("Ability_1/lock").GetComponent<Image>().enabled = false;
        }
        //if (level > 2)
        //{
        //    // unlock spell_2
        //    GameObject.FindWithTag("Player").GetComponent<Ability_2>().enabled = true;
        //    GameObject.Find("Ability_2/lock").GetComponent<Image>().enabled = false;
        //}
        //if (level > 3)
        //{
        //    // unlock spell_3
        //    GameObject.FindWithTag("Player").GetComponent<Ability_3>().enabled = true;
        //    GameObject.Find("Ability_3/lock").GetComponent<Image>().enabled = false;
        //}
        //if (level > 4)
        //{
        //    // unlock spell_4
        //    GameObject.FindWithTag("Player").GetComponent<Ability_4>().enabled = true;
        //    GameObject.Find("Ability_4/lock").GetComponent<Image>().enabled = false;
        //}
        //if (level > 5)
        //{
        //    // unlock spell_5
        //    GameObject.FindWithTag("Player").GetComponent<Ability_5>().enabled = true;
        //    GameObject.Find("Ability_5/lock").GetComponent<Image>().enabled = false;
        //}
    }

}
