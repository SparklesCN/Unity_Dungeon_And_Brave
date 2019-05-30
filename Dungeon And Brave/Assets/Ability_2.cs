using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_2 : MonoBehaviour
{
    public int damageAmount = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }
}
