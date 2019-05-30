using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float stopDistanceWithPlay = 3;
    public float rangeToSee = 10 ;
    public bool ableToAttack;
    public bool isNaving;
    public int habitat = 20;

    Vector3 startingPoint;          
    //public GameObject test;
    Animation anim;
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    Transform enemy;
    Animator ac;
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

        ableToAttack = false;
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
                    if (Vector3.Distance(startingPoint, curPos) < 1)
                    {
                        // arrive string point
                        nav.enabled = false;
                        ableToAttack = false;
                        //change rotation to 0, 180, 0
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime*2);

                        if (isAC)
                        {
                            // this enemy have AC;
                            // plz set bool and triger
                            ac.SetBool("isRun", false);

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
                        ableToAttack = false;
                        nav.SetDestination(startingPoint);
                        if (isAC)
                        {
                            // this enemy have AC;
                            // plz set bool and triger

                            ac.SetBool("isRun", true);
                            ac.SetBool("isAttack", false);

                        }
                        else
                        {
                            // this enemy only Animation
                            // plz switch between Anims
                            anim.Play("walk");
                        }
                    }
                }
                else if (Vector3.Distance(curPos, player.position) < stopDistanceWithPlay)
                {   //close enough to stop
                    nav.enabled = false;
                    ableToAttack = true;
                    if (isAC)
                    {
                        // this enemy have AC;
                        // plz set bool and triger
                        ac.SetBool("isAttack", true);

                    }
                    else
                    {
                        // this enemy only Animation
                        // plz switch between Anims
                        anim.Play("Attack");
                    }
                }
                else
                {   //see it,but not close enough 
                    nav.enabled = true;
                    ableToAttack = false;
                    nav.SetDestination(player.position);
                    if (isAC)
                    {
                        // this enemy have AC;
                        // plz set bool and triger
                        ac.SetBool("isRun", true);
                        ac.SetBool("isAttack", false);

                    }
                    else
                    {
                        // this enemy only Animation
                        // plz switch between Anims
                        anim.Play("walk");
                    }
                }
            }
            else
            {
                //Debug.Log(Vector3.Distance(curPos, player.position));
                // at the edge of it's habitat
                if (Vector3.Distance(curPos, player.position) > rangeToSee)
                {   //can't see player
                    Debug.Log("goback");
                    nav.enabled = true;
                    ableToAttack = false;
                    nav.SetDestination(startingPoint);
                    if (isAC)
                    {
                        // this enemy have AC;
                        // plz set bool and triger
                        ac.SetBool("isRun", true);
                        ac.SetBool("isAttack", false);

                    }
                    else
                    {
                        // this enemy only Animation
                        // plz switch between Anims
                        anim.Play("walk");
                    }
                }
                else if (Vector3.Distance(curPos, player.position) < stopDistanceWithPlay)
                {


                    Debug.Log("attact");
                    nav.enabled = false;
                    ableToAttack = true;
                    if (isAC)
                    {
                        // this enemy have AC;
                        // plz set bool and triger
                        ac.SetBool("isAttack", true);

                    }
                    else
                    {
                        // this enemy only Animation
                        // plz switch between Anims
                        anim.Play("Attack");
                    }
                }
                else
                {
                Debug.Log("Wait");
                //wait
                nav.enabled = false;
                ableToAttack = false;

                if (isAC)
                {
                    // this enemy have AC;
                    // plz set bool and triger
                    ac.SetBool("isRun", false);
                    ac.SetBool("isAttack", false);
                }
                else
                {
                    // this enemy only Animation
                    // plz switch between Anims
                    anim.Play("Idle");
                }
                }
             

            }
        }
        else
        {
            nav.enabled = false;
            ableToAttack = false;
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
