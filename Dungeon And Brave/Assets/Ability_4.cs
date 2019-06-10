using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_4 : MonoBehaviour
{
    public int damageAmount = 50;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }
}
