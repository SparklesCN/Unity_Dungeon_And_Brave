using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Ability_1 : MonoBehaviour
{
    Image abilityCover;
    public GameObject ability;
    public Transform spellPos;
    public int magicCost;
    public string key = "1";
    float myTime = 0f;
    public float abilityGap = 1f;
    Animator anim;
    AudioSource playerAudio;
    //public AudioClip ability1_Clip;
    bool isFire;

    private void Start()
    {
        abilityCover = GameObject.Find("Ability_1/Cover").GetComponent<Image>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        myTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Ability();
        if (myTime > abilityGap)
        {
            abilityCover.enabled = false;
        }
        else
        {
            abilityCover.enabled = true;
        }
    }
    void Ability()
    {
        myTime += Time.deltaTime;
        isFire = Input.GetKeyDown(key) && myTime > abilityGap;

        if (isFire)
        {
            myTime = 0f;
            if (GetComponent<PlayerMagic>().TakeMagic(magicCost))
            {
                GameObject copy_attact = Instantiate(ability, spellPos.position, spellPos.rotation) as GameObject;

                //play audio on object ability1 itself, it will play when object ability1 creat and only play for once
                ////play ability1 sound
                //playerAudio.clip = ability1_Clip;
                //playerAudio.Play();
            }

        }
        anim.SetBool("isAbility", isFire);
    }


}
