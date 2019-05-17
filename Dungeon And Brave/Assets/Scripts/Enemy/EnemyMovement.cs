using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float stopDistanceWithPlay = 3;
    public float rangeToSee = 10 ;
    public bool ableToAttact;
    public bool isNaving;
    public int habitat = 20;

    Vector3 startingPoint;          
    //public GameObject test;
    Animation anim;
    Animator ac;
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    Transform enemy;
    bool isAC = false;


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startingPoint = GetComponent<Transform>().position;
        anim = GetComponent<Animation>();
        enemy = GetComponent<Transform>();
        if (GetComponent<Animator>())
        {
            isAC = true;
            ac = GetComponent< Animator >();

        }

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
                    Debug.Log(Vector3.Distance(startingPoint, curPos));
                    if (Vector3.Distance(startingPoint, curPos) < 1)
                    {
                        // arrive string point
                        nav.enabled = false;
                        ableToAttact = false;
                        //change rotation to 0, 180, 0
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime*2);

                        if (isAC)
                        {
                            // this enemy have AC;
                            // plz set bool and triger
                            //ac.SetBool();

                        }
                        else 
                        {
                            // this enemy only Animation
                            // plz switch between Anims
                            anim.Play("Idle");
                        }
                    }
                    else
                    {
                        nav.enabled = true;
                        ableToAttact = false;
                        anim.Play("walk");
                        nav.SetDestination(startingPoint);
                    }
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
                if (Vector3.Distance(curPos, player.position) > rangeToSee)
                {   //can't see player
                    nav.enabled = true;
                    ableToAttact = false;
                    nav.SetDestination(startingPoint);
                }
                else
                {
                    nav.enabled = false;
                    ableToAttact = false;
                    anim.Play("Idle");

                }

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
