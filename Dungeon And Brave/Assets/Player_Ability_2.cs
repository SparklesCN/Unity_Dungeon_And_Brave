using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability_2 : MonoBehaviour
{
    public int magicCost;
    public string key = "2";
    float myTime = 0f;
    public float abilityGap = 1f;
    ParticleSystem healParticle, particlePart1, particlePart2, particlePart3;
    public int healAmount = 40;
    PlayerHealth playerHealth;
    Animator anim;

    AudioSource playerAudio;
    public AudioClip ability2_Clip;

    // Start is called before the first frame update
    void Awake()
    {
        healParticle = GameObject.Find("Ab2").GetComponent<ParticleSystem>();
        particlePart1 = GameObject.Find("Ab2/Circle_Light").GetComponent<ParticleSystem>();
        particlePart2 = GameObject.Find("Ab2/Silk").GetComponent<ParticleSystem>();
        particlePart3 = GameObject.Find("Ab2/Spark1").GetComponent<ParticleSystem>();
        healParticle.Stop();
        particlePart1.Stop();
        particlePart2.Stop();
        particlePart3.Stop();
        playerHealth = this.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
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
                particlePart1.Play();
                particlePart2.Play();
                particlePart3.Play();

                //play sound
                playerAudio.clip = ability2_Clip;
                playerAudio.Play();

                if (playerHealth.currentHealth >= 70)
                {
                    playerHealth.currentHealth = 100;
                }
                else
                {
                    playerHealth.currentHealth += healAmount;
                }
                
            }

        }
        anim.SetBool("isAbility", isFire);
    }


}
