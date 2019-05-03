using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attact;
    public Transform spellPos;
    float myTime = 0f;
    public float attactGap = 1f;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        myTime += Time.deltaTime;
        bool isFire = Input.GetButton("Fire1") && myTime > attactGap;

        if (isFire)
        {
            //Instantiate(Object original, Vector3 position, Quaternion rotation)
            GameObject copy_attact = Instantiate(attact, spellPos.position, spellPos.rotation) as GameObject;
            myTime = 0f;
        }
        anim.SetBool("isAttack", isFire);
    }


}
