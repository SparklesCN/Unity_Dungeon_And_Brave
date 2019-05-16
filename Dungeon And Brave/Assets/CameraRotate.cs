using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed = 100;       //设置旋转的速度
    public Transform PlayerTrans;       //设置空物体的位置

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float nor = Input.GetAxis("Mouse X");//获取鼠标的偏移量
            PlayerTrans.RotateAround(PlayerTrans.position, Vector3.up, Time.deltaTime * rotateSpeed * nor);//每帧旋转空物体，相机也跟随旋转
        }

    }

}
