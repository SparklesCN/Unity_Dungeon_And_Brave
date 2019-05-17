using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attact;
    public Transform spellPos;

    Text expText, levelText;
    Slider levelSlider;
    float myTime = 0f;
    public float attackGap = 1f;
    Animator anim;
    float target = 280;

    int level = 1;
    int curEXP = 100;
    public int constantOFlevel = 1;
    //source:https://www.diablowiki.net/Experience_level_chart
    IList<int> expList = new List<int> {0, 280, 2700, 4500, 6600, 9000, 11700, 14000, 16500, 19200};


    private void Start()
    {
        anim = GetComponent<Animator>();
        levelSlider = GameObject.Find("LevelSlider").GetComponent<Slider>();
        expText = GameObject.Find("ExpText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        expText.text = curEXP.ToString() + "/" + target.ToString();
        levelText.text = "Level: " + level.ToString();
        if (curEXP == 0)
        {
            curEXP += 1;
        }
        Debug.Log(curEXP);
        levelSlider.value = curEXP / target * 100;

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
        target = expList[level-1];
        curEXP += enemyExp;
        if (curEXP >= target)
        {
            curEXP = 0;
            level++;
            constantOFlevel = (int) (constantOFlevel * 1.2f);
        }

    }


}
