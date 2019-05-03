using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attact;
    public Transform spellPos;
    float myTime = 0f;
    float nextFire = 0.5f;
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
        bool isFire = Input.GetButton("Fire1") && myTime > nextFire;

        if (isFire)
        {
            nextFire += attactGap;
            //Instantiate(Object original, Vector3 position, Quaternion rotation)
            GameObject copy_attact = Instantiate(attact, spellPos.position, spellPos.rotation) as GameObject;
        }
        anim.SetBool("isAttack", isFire);
    }


}
