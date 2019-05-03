using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float stopDistanceWithPlay;
    public bool isNaving;
    //public GameObject test;
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && Vector3.Distance(GetComponent<Transform>().position, player.position) > stopDistanceWithPlay)
        {

            nav.enabled = true;
            isNaving = true;
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
            isNaving = false;
        }
    }

    /*private void OnParticleCollision(GameObject other)
    {
        Debug.Log("hit!");
        test = other;
    }*/


}
