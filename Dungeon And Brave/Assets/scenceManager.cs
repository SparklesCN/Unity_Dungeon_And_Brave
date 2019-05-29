using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scenceManager : MonoBehaviour
{
    GameObject player;
    List<string> Scenes = new List<string>(new string[] { "Map1", "Map2", "Map3", "Map4", "Map5" });

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetInt("SceneNum", PlayerPrefs.GetInt("SceneNum")+1);
            PlayerPrefs.SetInt("HP", player.GetComponent<PlayerHealth>().currentHealth);
            PlayerPrefs.SetInt("MP", player.GetComponent<PlayerMagic>().currentMagic);
            PlayerPrefs.SetInt("LV", player.GetComponent<PlayerAttack>().level);
            PlayerPrefs.SetInt("EXP", player.GetComponent<PlayerAttack>().curEXP);

            Debug.Log("SceneNum is " + PlayerPrefs.GetInt("SceneNum"));
            SceneManager.LoadSceneAsync(Scenes[PlayerPrefs.GetInt("SceneNum") - 1]);
        }
    }
}
