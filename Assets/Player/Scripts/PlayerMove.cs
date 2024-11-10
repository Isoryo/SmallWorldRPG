using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] private Animator anim;
    float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(inputHorizontal) > 0 || Mathf.Abs(inputVertical) > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jumping");
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("SSAttacking");
        }
        if(Input.GetKeyDown(KeyCode.Q))//普通のGetKeyでやると２回作動しちゃう
        {
            anim.SetTrigger("SmallDamage");
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("BigDamage");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Winning");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Losing");
        }
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        transform.position += moveForward * moveSpeed * Time.deltaTime;

        //進む方向に滑らかに向く。
        transform.forward = Vector3.Slerp(transform.forward, moveForward, Time.deltaTime * rotateSpeed);
    }
}
