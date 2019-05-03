using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public int damageAmount;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
        Destroy(gameObject);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
