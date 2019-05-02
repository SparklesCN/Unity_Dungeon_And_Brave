//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 6f;            // The speed that the player will move at.

//    Vector3 movement;                   // The vector to store the direction of the player's movement.
//    Animator anim;                      // Reference to the animator component.
//    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
//    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
//    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

//    void Awake()
//    {
//        // Create a layer mask for the floor layer.
//        floorMask = LayerMask.GetMask("Floor");

//        // Set up references.
//        anim = GetComponent<Animator>();
//        playerRigidbody = GetComponent<Rigidbody>();
//    }


//    void FixedUpdate()
//    {
//        // Store the input axes.
//        float h = Input.GetAxisRaw("Horizontal");
//        float v = Input.GetAxisRaw("Vertical");

//        // Move the player around the scene.
//        Move(h, v);

//        // Turn the player to face the mouse cursor.
//        Turning();

//        // Animate the player.
//        Animating(h, v);
//    }

//    void Move(float h, float v)
//    {
//        // Set the movement vector based on the axis input.
//        movement.Set(h, 0f, v);

//        // Normalise the movement vector and make it proportional to the speed per second.
//        movement = movement.normalized * speed * Time.deltaTime;

//        // Move the player to it's current position plus the movement.
//        playerRigidbody.MovePosition(transform.position + movement);
//    }

//    void Turning()
//    {
//        // Create a ray from the mouse cursor on screen in the direction of the camera.
//        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

//        // Create a RaycastHit variable to store information about what was hit by the ray.
//        RaycastHit floorHit;

//        // Perform the raycast and if it hits something on the floor layer...
//        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
//        {
//            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
//            Vector3 playerToMouse = floorHit.point - transform.position;

//            // Ensure the vector is entirely along the floor plane.
//            playerToMouse.y = 0f;

//            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
//            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

//            // Set the player's rotation to this new rotation.
//            playerRigidbody.MoveRotation(newRotation);
//        }
//    }

//    void Animating(float h, float v)
//    {
//        // Create a boolean that is true if either of the input axes is non-zero.
//        bool walking = h != 0f || v != 0f;

//        // Tell the animator whether or not the player is walking.
//        anim.SetBool("isRun", walking);
//    }
//}



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
        //speed = speed * Time.deltaTime;
        floor = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per every physic update
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Move(x, z);
        Turning();
        Animation(x, z);
    }

    private void Move(float x, float z)
    {
        //according to input come up with vector3
        move.Set(x, 0f, z); 
        //normalize
        move = move.normalized * speed * Time.deltaTime;
        //transform.position = Vector3.Lerp(transform.position, transform.position + move, speed);
        playerRigidbody.MovePosition(transform.position + move);
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


    private void Animation(float x, float z)
    {
        bool runing = x != 0f || z != 0f;

        anim.SetBool("isRun", runing);
    }

}
