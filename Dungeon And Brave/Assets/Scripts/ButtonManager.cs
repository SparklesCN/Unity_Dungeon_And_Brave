﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    Canvas loadingCanvas;
    Slider loadingSlider;
    int currentProgress, targetProgress;
    Text tutorialText1, tutorialText2, tutorialText3, menuButtonText;
    Image tutorialBackground, menuButtonImage;
    Button menuButton;
    // Start is called before the first frame update
    void Start()
    {
        Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        Button tutorialButton = GameObject.Find("TutorialButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnClickStart);
        exitButton.onClick.AddListener(OnClickExit);
        tutorialButton.onClick.AddListener(OnClickTutorial);
        menuButton.onClick.AddListener(OnClickMenu);

        tutorialText1 = GameObject.Find("TutorialText1").GetComponent<Text>();
        tutorialText2 = GameObject.Find("TutorialText2").GetComponent<Text>();
        tutorialText3 = GameObject.Find("TutorialText3").GetComponent<Text>();
        tutorialBackground = GameObject.Find("TutorialBackGround").GetComponent<Image>();
        menuButtonImage = GameObject.Find("MenuButton").GetComponent<Image>();
        menuButtonText = GameObject.Find("MenuButtonText").GetComponent<Text>();

        currentProgress = 0;
        targetProgress = 0;
        loadingSlider = GameObject.Find("LoadingSlider").GetComponent<Slider>();
        loadingCanvas = GameObject.Find("LoadingCanvas").GetComponent<Canvas>();

    }

    private void OnClickExit()
    {
        Debug.Log("Clicked! Exit!");
        Application.Quit();
    }
    private void OnClickStart()
    {
        loadingCanvas.enabled = true;
        StartCoroutine(LoadingScene());
    }
    private void OnClickTutorial()
    {
        tutorialText1.enabled = true;
        tutorialText2.enabled = true;
        tutorialText3.enabled = true;

        tutorialBackground.enabled = true;
        menuButton.enabled = true;
        menuButtonImage.enabled = true;
        menuButtonText.enabled = true;
    }
    private void OnClickMenu()
    {
        tutorialText1.enabled = false;
        tutorialText2.enabled = false;
        tutorialText3.enabled = false;

        tutorialBackground.enabled = false;
        menuButton.enabled = false;
        menuButtonImage.enabled = false;
        menuButtonText.enabled = false;
    }

    private IEnumerator LoadingScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1); //load next map
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
