using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    public int startingMagic = 100;            // The amount of health the enemy starts the game with.
    public int currentMagic;                   // The current health the enemy has.
    Slider magicSlider;

    void Awake()
    {
        magicSlider = GameObject.Find("MagicSlider").GetComponent<Slider>();

        // Setting the current health when the enemy first spawns.
        currentMagic = PlayerPrefs.GetInt("MP");
        magicSlider.value = currentMagic;
    }

    void Update()
    {
        magicSlider.value = currentMagic;
        //if (Input.GetKeyDown("2"))
        //{
        //    currentMagic = 100;
        //}
    }


    public void TakeMagic(int amount)
    {
        // Reduce the current health by the amount of damage sustained.
        currentMagic -= amount;
    }
}
