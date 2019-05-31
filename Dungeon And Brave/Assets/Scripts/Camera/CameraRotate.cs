using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed = 100;       //设置旋转的速度
    public Transform PlayerTrans;       //设置空物体的位置
    GameObject player;
    PlayerHealth playerHealth;
    float dis;
    GameObject cameraInit;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        dis = Vector3.Distance(player.transform.position, transform.position);
        cameraInit = GameObject.FindGameObjectWithTag("CameraInitial");
    }

    void Update()
    {

        Vector3 cameraInitpos = cameraInit.transform.position;
        if (Input.GetMouseButton(1) && playerHealth.currentHealth > 0)
        {
            float nor = Input.GetAxis("Mouse X");//获取鼠标的偏移量
            //public void RotateAround(Vector3 point, Vector3 axis, float angle);
            //Rotates the transform(point) about axis passing through point in world coordinates by angle degrees.
            PlayerTrans.RotateAround(PlayerTrans.position, Vector3.up, Time.deltaTime * rotateSpeed * nor);//每帧旋转空物体，相机也跟随旋转
        }


        RaycastHit hit;
        //player's local position is 0,0,0
        Vector3 player_position = player.transform.position;
        //Debug.Log(transform.localPosition);

        // if the ray from player to camera, hit something
        if (Physics.Linecast(player_position+Vector3.up,cameraInitpos, out hit))
        {
            //check if object that we hit has object
            string tag = hit.collider.gameObject.tag;
            if (tag == "Camera")
            {
                //Debug.Log(hit.point);
                //move camera foward
                float cur_dis = Vector3.Distance(hit.point, player_position);
                if (cur_dis < dis)
                {
                    transform.position = hit.point;
                }
            }
            else
            {
                transform.localPosition = new Vector3(0, 200, -260);
            }

        }

    }
}