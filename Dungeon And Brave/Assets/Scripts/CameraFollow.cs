using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    // Start is called before the first frame update
    Vector3 constant;
    void Start()
    {
        constant = target.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // new position
        Vector3 pos = target.position - constant;
        // smoothly change to new position
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);

    }
}
