using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenceManager : MonoBehaviour
{
    GameObject player;
    int currentProgress, targetProgress;
    Slider loadingSlider;
    Canvas loadingCanvas;
    List<string> Scenes = new List<string>(new string[] { "Map1", "Map2", "Map3", "Map4", "Map5" });

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentProgress = 0;
        targetProgress = 0;
        loadingSlider = GameObject.Find("LoadingSlider").GetComponent<Slider>();
        loadingCanvas = GameObject.Find("LoadingCanvas").GetComponent<Canvas>();

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

            //SceneManager.LoadSceneAsync(Scenes[PlayerPrefs.GetInt("SceneNum") - 1]);

            loadingCanvas.enabled = true;

            // TODO: play teleport sounds here;

            StartCoroutine(LoadingScene()); 

        }
    }

    // reference : https://blog.csdn.net/ChinarCSDN/article/details/80947281#loading-scene-%E5%8A%A0%E8%BD%BD%E5%9C%BA%E6%99%AF
    // Asynchronous loading
    private IEnumerator LoadingScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNum")); //load next map
        asyncOperation.allowSceneActivation = false;                          //Ban auto load after loading
        while (asyncOperation.progress < 0.9f)                                //when progress less than 0.9f
        {
            targetProgress = (int)(asyncOperation.progress * 100); //when progress in allowSceneActivation= false，will stuck on 0.89999，time 100 to get int
            yield return LoadProgress();
        }
        targetProgress = 100; 
        yield return LoadProgress();
        asyncOperation.allowSceneActivation = true; 
    }

    private IEnumerator<WaitForEndOfFrame> LoadProgress()
    {
        while (currentProgress < targetProgress)
        {
            ++currentProgress;                            
            loadingSlider.value = (float)currentProgress / 100; 
            yield return new WaitForEndOfFrame();        
        }
    }

}
