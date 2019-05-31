// refer: Unity_Survival_Shooter Tutorial
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    Slider healthSlider;                                 // Reference to the UI's health bar.

    Animator anim;                                              // Reference to the Animator component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    bool isDead;                                                // Whether the player is dead.

    public AudioClip deathClip;
    AudioClip hurtClip;
    AudioSource playerAudio;

    Canvas loadingCanvas;
    Slider loadingSlider;
    int currentProgress, targetProgress;

    void Awake()
    {
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();

        // Setting up the references.
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        // Set the initial health of the player.
        currentHealth = PlayerPrefs.GetInt("HP");
        healthSlider.value = currentHealth;
        playerAudio = GetComponent<AudioSource>();
        hurtClip = playerAudio.clip;
        currentProgress = 0;
        targetProgress = 0;
        loadingSlider = GameObject.Find("LoadingSlider").GetComponent<Slider>();
        loadingCanvas = GameObject.Find("LoadingCanvas").GetComponent<Canvas>();


    }

    void Update()
    {
        //if (Input.GetKeyDown("1"))
        //{
        //    currentHealth = 100;
        //}
        healthSlider.value = currentHealth;
    }


    public void TakeDamage(int amount)
    {
 
        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        //play hurt audio
        playerAudio.clip = hurtClip;
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        // Tell the animator that the player is dead.
        anim.SetTrigger("Dead");

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;

        //play death audio
        playerAudio.clip = deathClip;
        playerAudio.Play();
        loadingCanvas.enabled = true;
        StartCoroutine(LoadingScene());

    }

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