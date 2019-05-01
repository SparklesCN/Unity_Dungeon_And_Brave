using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 move;
    Rigidbody playerRigidbody;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.deltaTime;
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // FixedUpdate is called once per every physic update
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Move(x, z);
        Anmi(x, z);
    }

    void Move(float x, float z)
    {
        //according to input come up with vector3
        move.Set(x, 0f, z);
        //normalize
        move = move.normalized;
        playerRigidbody.MovePosition(transform.position + move * speed);
    }

    void Anmi(float x, float z)
    {
        bool runing = x != 0f || z != 0f;
        anim.SetBool("isRun", runing);
    }

}
