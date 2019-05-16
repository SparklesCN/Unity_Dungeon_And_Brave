using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public int damageAmount;
    public float lifetime = 2f;
    int c;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", lifetime);
        player = GameObject.FindGameObjectWithTag("Player");
        c = player.GetComponent<PlayerAttack>().constantOFlevel;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageAmount * c);
        }
        Destroy(gameObject);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
