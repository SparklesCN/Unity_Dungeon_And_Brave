﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonManager : MonoBehaviour
{

    Button pauseButton, resumptionButton, exitButton;
    Image pauseButtonImage, resumptionImage, exitImage, pauseBackgroundImage;

    // Start is called before the first frame update
    void Start()
    {

        // refer all buttons
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        resumptionButton = GameObject.Find("ResumptionButton").GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        // refer all images
        pauseButtonImage = GameObject.Find("PauseButton").GetComponent<Image>();
        resumptionImage = GameObject.Find("ResumptionButton").GetComponent<Image>();
        exitImage = GameObject.Find("ExitButton").GetComponent<Image>();
        pauseBackgroundImage = GameObject.Find("PauseBackground").GetComponent<Image>();

        // bound all buttons with events
        pauseButton.onClick.AddListener(OnClickPause);
        resumptionButton.onClick.AddListener(OnClickResumption);
        exitButton.onClick.AddListener(OnClickExit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            OnClickPause();
        }
    }

    private void OnClickPause()
    {
        // TODO: play button sounds here;

        Time.timeScale = 0;

        //enable all pause UI
        //images
        pauseBackgroundImage.enabled = true;
        resumptionImage.enabled = true;
        exitImage.enabled = true;
        //buttons
        resumptionButton.enabled = true;
        exitButton.enabled = true;
    }

    private void OnClickExit()
    {
        // TODO: play button sounds here;

        Application.Quit();
    }

    private void OnClickResumption()
    {
        // TODO: play button sounds here;

        Time.timeScale = 1;

        //disable all pause UI
        //images
        pauseBackgroundImage.enabled = false;
        resumptionImage.enabled = false;
        exitImage.enabled = false;
        //buttons
        resumptionButton.enabled = false;
        exitButton.enabled = false;
    }
}
