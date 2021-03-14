using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper_Tachibana : MonoBehaviour {
	// Inspecterで値を変更する
	public float spring = 40000;
	public float openAngle = 25; // 開く角度
	public float closeAngle = -25; // 閉じる角度

	// Hinge Joint
	private HingeJoint hjL; // AxisL
	//private HingeJoint hjR; // AxisR

	// JointSpring
	private JointSpring jL; // AxisL
	//private JointSpring jR; // AxisR

	void Start() {
		// AxisLとAxisRを探す
		GameObject flipperL = GameObject.Find("AxisL");
		//GameObject flipperR = GameObject.Find("AxisR");

		// HingeJointを受け取る
		hjL = flipperL.GetComponent<HingeJoint>();
		//hjR = flipperR.GetComponent<HingeJoint>();

		// Springを受け取る
		jL = hjL.spring;
		//jR = hjR.spring;
	}

	void Update() {
		// 左クリックを押す
		if (Input.GetMouseButtonDown(0)) {
			jL.spring = spring;
			jL.targetPosition = openAngle;
			hjL.spring = jL;

		}
		// 左クリックを離す
		if (Input.GetMouseButtonUp(0)) {
			jL.spring = spring;
			jL.targetPosition = closeAngle;
			hjL.spring = jL;
		}
		// 右クリックを押す
		if (Input.GetMouseButtonDown(1)) {
			//jR.spring = spring;
			//jR.targetPosition = -openAngle;
			//hjR.spring = jR;
		}
		// 右クリックを離す
		if (Input.GetMouseButtonUp(1)) {
			//jR.spring = spring;
			//jR.targetPosition = closeAngle;
			//hjR.spring = jR;
		}
	}
}