using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPort : MonoBehaviour
{
    BoxCollider portCollider;
    ParticleSystem silkParticle, verParticle;
    bool isPlayed;

    private void Start()
    {
        portCollider = GameObject.Find("PortCollider").GetComponent<BoxCollider>();
        silkParticle = GameObject.Find("Silk").GetComponent<ParticleSystem>();
        verParticle = GameObject.Find("ver").GetComponent<ParticleSystem>();
        silkParticle.Stop();
        verParticle.Stop();
        isPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            if (!isPlayed)
            {
                silkParticle.Play();
                verParticle.Play();
                isPlayed = true;
            }
            
            portCollider.enabled = true;
        }
    }
}
