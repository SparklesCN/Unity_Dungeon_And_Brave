using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPort : MonoBehaviour
{
    BoxCollider portCollider;

    private void Start()
    {
        portCollider = GameObject.Find("PortCollider").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            portCollider.enabled = true;
        }
    }
}
