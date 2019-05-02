using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharacterThirdControl : MonoBehaviour
{

    Transform myCamera;  //跟随摄像机
    private CharacterController cc;
    Vector3 playerDirect;         //角色的目标方向
    Vector3 correctDirect;       //为了矫正计算方向向量的误差
    float perError = 0.2f;       //误差与摄像机缓冲存在关系
    float speed = 0.1f;            //速度与Update的帧数有关，同样数据帧数越多，速度越快
    Vector3 front;  //前
    Vector3 back;  //后
    Vector3 left;    //左
    Vector3 right; //右
    // Use this for initialization
    void Start()
    {
        myCamera = Camera.main.transform;  //将主摄像机设置为跟随摄像机
        front = Vector3.zero;
        back = Vector3.zero;
        left = Vector3.zero;
        right = Vector3.zero;
        correctDirect = Vector3.zero;
        cc = transform.GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        PlayerControl();
    }

    /// <summary>
    /// 计算方向向量函数
    /// </summary>
    private void CalculateDirection()
    {
        Vector3 temp = transform.position - myCamera.position;
        temp = new Vector3(temp.x, 0, temp.z);
        front = temp;
        if (correctDirect != Vector3.zero && Mathf.Abs(correctDirect.x - front.x) < perError && Mathf.Abs(correctDirect.z - front.z) < perError)  //判断是否在误差范围内
        {
            front = correctDirect;
        }
        back = -front;
        left = new Vector3(-front.z, 0, front.x);
        right = -left;
        correctDirect = front;
    }

    /// <summary>
    /// 控制角色移动
    /// </summary>
    private void PlayerControl()
    {
        playerDirect = new Vector3(0, 0, 0);

        CalculateDirection();    //计算角色的方向

        if (Input.GetAxis("Horizontal") < 0)  //左
        {
            playerDirect = left;
        }
        if (Input.GetAxis("Horizontal") > 0)  //右
        {
            playerDirect = right;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (Input.GetAxis("Horizontal") < 0)  //前左
            {
                playerDirect = front + left;
            }
            else if (Input.GetAxis("Horizontal") > 0) //前右
            {
                playerDirect = front + right;
            }
            else
            {
                playerDirect = front;     //前
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Horizontal") < 0)    //后左
            {
                playerDirect = back + left;
            }
            else if (Input.GetAxis("Horizontal") > 0)   //后右
            {
                playerDirect = back + right;
            }
            else
            {
                playerDirect = back;     //后
            }
        }
        if (playerDirect != Vector3.zero)
        {
            playerDirect += transform.position;
            MoveSpeed(playerDirect);
        }
    }


    /// <summary>
    /// 调整角色方向，控制角色移动
    /// </summary>
    private void MoveSpeed(Vector3 direct)
    {
        transform.LookAt(new Vector3(direct.x, transform.position.y, direct.z));
        cc.Move(transform.forward * speed);
    }
}
