// refer: Unity_Survival_Shooter Tutorial

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.

    Animator anim;                                              // Reference to the Animator component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    bool isDead;                                                // Whether the player is dead.


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }

    void Update()
    {
    }


    public void TakeDamage(int amount)
    {
 
        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;


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
    }

}