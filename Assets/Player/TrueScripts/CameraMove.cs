using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPos;
    [SerializeField] public float cameraRotateSensitivity = 200f;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("unitychan");
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * cameraRotateSensitivity);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * cameraRotateSensitivity * -1);
        }

}
}
