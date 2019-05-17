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
    int curEXP = 1;
    public int constantOFlevel = 1;
    //source:https://www.diablowiki.net/Experience_level_chart
    IList<int> expList = new List<int> {280, 2700, 4500, 6600, 9000, 11700, 14000, 16500, 19200};


    private void Start()
    {
        Invoke("DismissTutorialInfo", 5f);
        target = expList[level - 1];
        anim = GetComponent<Animator>();
        levelSlider = GameObject.Find("LevelSlider").GetComponent<Slider>();
        expText = GameObject.Find("ExpText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        expText.text = "Exp: " + curEXP.ToString() + "/" + target.ToString();
        levelText.text = "Level: " + level.ToString();

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

    public void getExp(int enemyExp)
    {

        curEXP += enemyExp;
        if (curEXP >= target)
        {
            LevelUp();
        }

    }

    void LevelUp()
    {
        curEXP = 0;
        level++;
        constantOFlevel = (int)(constantOFlevel * 1.2f);
        target = expList[level - 1];

        // unlock speel_ 1
        GameObject.Find("Ability_1/lock").GetComponent<Image>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<Player_Ability_1>().enabled = true;
        GameObject.Find("LevelUpText").GetComponent<Text>().enabled = true;
        GameObject.Find("AbUnlockText").GetComponent<Text>().enabled = true;

        Invoke("DismissLevelUpInfo", 5f);
        Invoke("DismissAbilityUnlockInfo", 5f);
    }
    void DismissTutorialInfo()
    {
        GameObject.Find("TutorialText").GetComponent<Text>().enabled = false;
    }
    void DismissLevelUpInfo()
    {
        GameObject.Find("LevelUpText").GetComponent<Text>().enabled = false;
    }

    void DismissAbilityUnlockInfo()
    {
        GameObject.Find("AbUnlockText").GetComponent<Text>().enabled = false;
    }

}
