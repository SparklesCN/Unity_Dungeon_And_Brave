using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 50f;
    public float moveSpeed = 10f;


    // Start is called before the first frame update
    Vector3 constant;
    void Start()
    {
        constant = target.position - transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // new position
        Vector3 pos = target.position - constant;
        // smoothly change to new position
        //transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);

        RaycastHit hit;
        // if the ray from player to camera, hit something
        if (Physics.Linecast(target.position + Vector3.up, pos, out hit))
        {
            //check if object that we hit has object
            //string tag = hit.collider.gameObject.tag;
            //if (tag == "Camera")
            //{
            //move camera foward
            Debug.Log("hit");
            transform.position = hit.point;
            //transform.position = Vector3.Lerp(transform.position, hit.point, speed * Time.deltaTime);

            //} 
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }

    }
}
//// 第三人称镜头跟随，鼠标控制镜头缩放和环绕
//// refer: https://blog.csdn.net/chq1240/article/details/69167425
//public class CameraFollow : MonoBehaviour
//{
//    //请在Editor界面选定摄像头的锁定目标，推荐选定模型的头部文件
//    public Transform target;
//    //防止镜头卡死,在使用前把镜头放在合适位置 
//    Vector3 CameraDis;
//    // 初始化 
//    void Start()
//    {
//        CameraDis = transform.position - target.position;
//    }
//    void LateUpdate()
//    {

//        Scale();
//        transform.position = target.position + CameraDis;
//        transform.LookAt(target);
//        Rotate();
//    }
//    //缩放
//    private void Scale()
//    {
//        float Scaledis = CameraDis.magnitude;
//        Scaledis -= Input.GetAxis("Mouse ScrollWheel") * 5;
//        //限制缩放
//        if ((Scaledis <= 2))
//        {
//            Scaledis = 2;
//        }
//        else if (Scaledis >= 8)
//            Scaledis = 8;
//        CameraDis = CameraDis.normalized * Scaledis;
//    }
//    //摄像头环绕
//    private void Rotate()
//    {
//        //速度可以通过修改数字来调整
//        transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * 10);
//        float t = Input.GetAxis("Mouse Y") * -1 / 5;
//        CameraDis = transform.position - target.position;
//        CameraDis.y += t;
//        //对旋转的角度加以限制
//        if (CameraDis.y >= 2)
//        {
//            CameraDis.y = 2;
//        }
//        else if (CameraDis.y <= 0)
//        {
//            CameraDis.y = 0;
//        }
//    }
//}

