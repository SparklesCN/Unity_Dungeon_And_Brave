using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControlor : MonoBehaviour
{
    public static DataControlor Instance;
    public GameObject player;

    public int HP, MP, LV, EXP, SceneNum;
    private void Awake()
    {
        // Instance mode
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void saveData()
    {
        DataControlor.Instance.SceneNum = SceneNum;
        DataControlor.Instance.HP = player.GetComponent<PlayerHealth>().currentHealth;
        DataControlor.Instance.MP = player.GetComponent<PlayerMagic>().currentMagic;
        DataControlor.Instance.LV = player.GetComponent<PlayerAttack>().level;
        DataControlor.Instance.EXP = player.GetComponent<PlayerAttack>().curEXP;

    }
}
