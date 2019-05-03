using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float stopDistanceWithPlay;
    public float rangeToSee;
    public bool ableToAttact;
    public bool isNaving;
    public int habitat;
    Vector3 startingPoint;
    //public GameObject test;
    Animation anim;
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
        startingPoint = GetComponent<Transform>().position;
        anim = GetComponent<Animation>();
        ableToAttact = false;
    }


    void Update()
    {
        Vector3 curPos = GetComponent<Transform>().position;
        // If the enemy and the player have health left...

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            //inside his habitat
            if (Vector3.Distance(startingPoint, curPos) < habitat)
            {
                if (Vector3.Distance(curPos, player.position) > rangeToSee)
                {   //can't see player
                    nav.enabled = true;
                    ableToAttact = false;
                    anim.Play("walk");
                    nav.SetDestination(startingPoint);
                }
                else if (Vector3.Distance(curPos, player.position) < stopDistanceWithPlay)
                {   //close enough to stop
                    nav.enabled = false;
                    ableToAttact = true;
                }
                else
                {   //see it,but not close enough 
                    nav.enabled = true;
                    ableToAttact = false;
                    anim.Play("walk");
                    nav.SetDestination(player.position);
                }
            }
            else
            {
                nav.enabled = true;
                ableToAttact = false;
                nav.SetDestination(startingPoint);
            }
        }
    //    if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && Vector3.Distance(GetComponent<Transform>().position, player.position) > stopDistanceWithPlay)
    //    {

    //        nav.enabled = true;
    //        isNaving = true;
    //        // ... set the destination of the nav mesh agent to the player.
    //        nav.SetDestination(player.position);
    //    }
    //    // Otherwise...
    //    else
    //    {
    //        // ... disable the nav mesh agent.
    //        nav.enabled = false;
    //        isNaving = false;
    //    }
    }

    /*private void OnParticleCollision(GameObject other)
    {
        Debug.Log("hit!");
        test = other;
    }*/


}
