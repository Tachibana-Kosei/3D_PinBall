using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanperScript : MonoBehaviour {

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	private float power = 200.0f;

	// リジッドボディに触れた時に呼ばれる
	private void OnCollisionEnter(Collision other) {
		// 今回はタグでプレイヤーかどうか判断
		if (other.transform.CompareTag("Ball")) {
			// プレイヤーのリジッドボディを取得
			Rigidbody ballRigid = other.transform.GetComponent<Rigidbody>();

			// プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
			ballRigid.AddForce(-ballRigid.velocity * power);

			//得点 addscore


		}
	}
}
