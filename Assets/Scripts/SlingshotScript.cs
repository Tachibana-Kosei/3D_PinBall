using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour
{
    
    MainSystemScript system;   
    private float power = 1000.0f;
    private AudioSource audioSource;

    private void Start()
    {
        system = GameObject.Find("MainSystem").GetComponent<MainSystemScript>();
        audioSource = GetComponent<AudioSource>();
    }


    // リジッドボディに触れた時に呼ばれる
    private void OnCollisionEnter(Collision other)
    {
        // 今回はタグでプレイヤーかどうか判断
        if (other.transform.CompareTag("Ball"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody ballRigid = other.transform.GetComponent<Rigidbody>();
            Vector3 disBall = (other.transform.position - transform.position).normalized;
            if ((disBall-transform.right).magnitude<(disBall+transform.right).magnitude)
            {
                ballRigid.AddForce(transform.right*power);
            }
            else
            {
                ballRigid.AddForce(-transform.right*power);
            }
            //Sound
            audioSource.Play();

            //得点 addscore
            system.AddScore(500);

        }
    }
}
