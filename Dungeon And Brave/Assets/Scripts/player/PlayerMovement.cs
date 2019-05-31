// Refer: Unity Tutorial - Survival Shooter
// https://unity3d.com/learn/tutorials/projects/survival-shooter/player-character?playlist=17144

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6f;
    Vector3 move;
    Rigidbody playerRigidbody;
    Animator anim;
    int floor;
    //float camRayL = 100f;
    AudioSource playerAudio;
    public AudioClip moveClip;

    float timerForClip = 0f;



    //public float moveSpeed = 2f;
    //public float rotateSpeed = 2f;

    // Start is called before the first frame update
    private void Awake()
    {
        //speed = speed * Time.deltaTime;
        floor = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        //timerForClip = 0f;

    }

    // FixedUpdate is called once per every physic update
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        timerForClip += Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.position += transform.forward * Time.deltaTime * movementSpeed;
            anim.SetBool("isRun", true);

            //play sond of movement
            PlayMoveClip();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.position -= transform.forward * Time.deltaTime * movementSpeed;
            anim.SetBool("isRun", true);

            //play sond of movement
            PlayMoveClip();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.position -= transform.right * Time.deltaTime * movementSpeed;
            anim.SetBool("isRun", true);

            //play sond of movement
            PlayMoveClip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.position += transform.right * Time.deltaTime * movementSpeed;
            anim.SetBool("isRun", true);

            //play sond of movement
            PlayMoveClip();
        }
        else 
        {
            anim.SetBool("isRun", false);
        }
        //Move(x, z);
        //Turning();
    }

    //private void Move(float x, float z)
    //{
    //    //according to input come up with vector3
    //    move.Set(x, 0f, z); 
    //    //normalize
    //    move = move.normalized * movementSpeed * Time.deltaTime;
    //    //transform.position = Vector3.Lerp(transform.position, transform.position + move, speed);
    //    playerRigidbody.MovePosition(transform.position + move);

    //    //refer: https://blog.csdn.net/lyh916/article/details/45952517

    //    //if (x != 0 || z != 0)
    //    //{
    //    //    Vector3 targetDirection = new Vector3(x, 0, z);
    //    //    float y = Camera.main.transform.rotation.eulerAngles.y;
    //    //    targetDirection = Quaternion.Euler(0, y, 0) * targetDirection;

    //    //    transform.Translate(targetDirection * Time.deltaTime * moveSpeed, Space.World);
    //    //}
    //    //if (Input.GetKey(KeyCode.J))
    //    //{
    //    //    transform.Rotate(-Vector3.up * Time.deltaTime * rotateSpeed);
    //    //}


    //     //test for instance create
    //    //Instantiate(attack, spellPos.position, spellPos.rotation).GetComponent<ParticleSystem>().Play();
    //}

    //private void Turning()
    //{
    //    Ray camR = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit floorHit;

    //    //Physics.Raycast(V3: origin, V3: driction, floaf: maxDis, int: layerMask,QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
    //    //return True if the ray intersects with a Collider, otherwise false.
    //    if (Physics.Raycast(camR, out floorHit, camRayL, floor))
    //    {
    //        Vector3 playToM = floorHit.point - transform.position;

    //        playToM.y = 0f;

    //        Quaternion rotation = Quaternion.LookRotation(playToM);

    //        playerRigidbody.MoveRotation(rotation);
    //    }


    //}


    private void Animation(float x, float z)
    {
        bool runing = x != 0f || z != 0f;

        anim.SetBool("isRun", runing);
    }

    void PlayMoveClip()
    {
        //play move sound

        if (timerForClip >= 0.3f)
        {
            playerAudio.clip = moveClip;
            playerAudio.Play();
            timerForClip = 0f;
        }
    }


}
