using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    public int enemyEXP = 10;
    Animation anim;                              // Reference to the animator.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
    Animator ac;
    bool isAC = false;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animation>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;

        if (GetComponent<Animator>())
        {
            isAC = true;
            ac = GetComponent<Animator>();

        }
    }

    void Update()
    {
        // If the enemy should be sinking...
        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount)
    {

        // If the enemy is dead...
        if (isDead)
        {
            // ... no need to take damage so exit the function.
            return;
        }


        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            isSinking = true;
            // ... the enemy is dead.
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        if (isAC)
        {
            // this enemy have AC;
            // plz set bool and triger
            ac.SetTrigger("Dead");

        }
        else
        {
            // this enemy only Animation
            // plz switch between Anims
            anim.Play("Death");
        }

        //calling level up function to update player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerAttack>().getExp(enemyEXP);
    }


    /*public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }*/
}