using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attact;
    public Transform spellPos;
    float myTime = 0f;
    public float attackGap = 1f;
    Animator anim;

    int level = 1;
    public int curEXP = 0;
    public int constantOFlevel = 1;
    //source:https://www.diablowiki.net/Experience_level_chart
    IList<int> expList = new List<int> {0, 280, 2700, 4500, 6600, 9000, 11700, 14000, 16500, 19200};


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
        bool isFire = Input.GetButton("Fire1") && myTime > attackGap;

        if (isFire)
        {
            //Instantiate(Object original, Vector3 position, Quaternion rotation)
            GameObject copy_attact = Instantiate(attact, spellPos.position, spellPos.rotation) as GameObject;
            myTime = 0f;
        }
        anim.SetBool("isAttack", isFire);
    }

    public void levelup(int enemyExp)
    {
        float target = expList[level-1];
        curEXP += enemyExp;
        if (curEXP >= target)
        {
            curEXP = 0;
            level++;
            constantOFlevel = (int) (constantOFlevel * 1.2f);
        }

    }


}
