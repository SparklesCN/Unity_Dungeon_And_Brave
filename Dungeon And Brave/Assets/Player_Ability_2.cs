using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability_2 : MonoBehaviour
{
    public int magicCost;
    public string key = "2";
    float myTime = 0f;
    public float abilityGap = 1f;
    ParticleSystem healParticle;
    public int healAmount = 40;
    PlayerHealth playerHealth;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        healParticle = GameObject.Find("Ab2").GetComponent<ParticleSystem>();
        healParticle.Stop();
        playerHealth = this.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        Ability();
    }
    void Ability()
    {
        myTime += Time.deltaTime;
        bool isFire = Input.GetKeyDown(key) && myTime > abilityGap;

        if (isFire)
        {
            myTime = 0f;
            if (GetComponent<PlayerMagic>().TakeMagic(magicCost))
            {
                healParticle.Play();
                if (playerHealth.currentHealth >= 70)
                {
                    playerHealth.currentHealth = 100;
                }
                else
                {
                    playerHealth.currentHealth += 30;
                }
                
            }

        }
        anim.SetBool("isAbility", isFire);
    }


}
