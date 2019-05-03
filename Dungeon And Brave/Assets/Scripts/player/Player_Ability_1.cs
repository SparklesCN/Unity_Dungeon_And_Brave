using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability_1 : MonoBehaviour
{
    public GameObject ability;
    public Transform spellPos;
    public int magicCost;
    float myTime = 0f;
    float nextFire = 0.5f;
    public float abilityGap = 1f;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ability();
    }
    void Ability()
    {
        myTime += Time.deltaTime;
        bool isFire = Input.GetKeyDown("q") && myTime > nextFire;

        if (isFire)
        {
            GetComponent<PlayerMagic>().TakeMagic(magicCost);
            nextFire += abilityGap;
            //Instantiate(Object original, Vector3 position, Quaternion rotation)
            GameObject copy_attact = Instantiate(ability, spellPos.position, spellPos.rotation) as GameObject;
        }
        anim.SetBool("isAbility", isFire);
    }


}
