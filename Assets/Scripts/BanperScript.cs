using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanperScript : MonoBehaviour {
	private float power = 1200f;

	MainSystemScript system;   
	// Start is called before the first frame update
	void Start() {
		system = GameObject.Find("MainSystem").GetComponent<MainSystemScript>();

	}

	// Update is called once per frame

	// リジッドボディに触れた時に呼ばれる
	private void OnCollisionEnter(Collision other) {
		// 今回はタグでプレイヤーかどうか判断
		if (other.transform.CompareTag("Ball")) {
			// プレイヤーのリジッドボディを取得
			Rigidbody ballRigid = other.transform.GetComponent<Rigidbody>();
			Vector3 ballSpeed = ballRigid.velocity;
			ballRigid.velocity=Vector3.zero;
			var disBall = ballRigid.transform.position - transform.position;

			// プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
			ballRigid.AddForce((disBall.normalized-ballSpeed.normalized) * power);

			//得点 addscore
			system.AddScore(500);


		}
	}
}
