using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 move;
    Rigidbody playerRigidbody;
    Animator anim;
    int floor;
    float camRayL = 100f;


    // Start is called before the first frame update
    private void Awake()
    {
        speed = speed * Time.deltaTime;
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        floor = LayerMask.GetMask("Floor");
    }

    // FixedUpdate is called once per every physic update
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Move(x, z);
        Turning();
        Anmi(x, z);
    }

    private void Move(float x, float z)
    {
        //according to input come up with vector3
        move.Set(x, 0f, z); 
        //normalize
        move = move.normalized;
        //transform.position = Vector3.Lerp(transform.position, transform.position + move, speed);
        playerRigidbody.MovePosition(transform.position + move * speed);
    }

    private void Turning()
    {
        Ray camR = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        //Physics.Raycast(V3: origin, V3: driction, floaf: maxDis, int: layerMask,QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        //return True if the ray intersects with a Collider, otherwise false.
        if (Physics.Raycast(camR, out floorHit, camRayL, floor))
        {
            Vector3 playToM = floorHit.point - transform.position;
            playToM.y = 0f;

            Quaternion rotation = Quaternion.LookRotation(playToM);
            playerRigidbody.MoveRotation(rotation);
        }


    }


    private void Anmi(float x, float z)
    {
        bool runing = (x != 0f) || (z != 0f);
        anim.SetBool("isRun", runing);
    }

}
