using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour
{
    
    MainSystemScript system;   
    private float power = 1000.0f;

    private void Start()
    {
        system = GameObject.Find("MainSystem").GetComponent<MainSystemScript>();
    }


    // リジッドボディに触れた時に呼ばれる
    private void OnCollisionEnter(Collision other)
    {
        // 今回はタグでプレイヤーかどうか判断
        if (other.transform.CompareTag("Ball"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody ballRigid = other.transform.GetComponent<Rigidbody>();

            // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
            ballRigid.AddForce(-ballRigid.velocity.normalized * power);

            //得点 addscore
            system.AddScore(500);

        }
    }
}
