using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlungerScript_Tachibana : MonoBehaviour {
	private GameObject BallSpowner;
	float power = 1.0f;
	public float maxPower = 30.0f;
	private Rigidbody rd;
	private Vector3 startPotision;
	private BoxCollider boxCollider;

	void Start() {
		rd = GetComponent<Rigidbody>();
		startPotision = this.transform.position;
		BallSpowner = GameObject.Find("BallSpowner");
		boxCollider = GetComponent<BoxCollider>();
	}

	void Update() {
		//押してる時
		if (Input.GetKey(KeyCode.Space)) {
			if (this.power < maxPower) {
				this.transform.position += new Vector3(0.0f, Mathf.Sin(Mathf.PI / 6.0f), Mathf.Cos(Mathf.PI / 6.0f)) * (-0.05f);//位置
				this.power += 0.75f;//力
			} else if (this.power > maxPower) {
				this.power = maxPower;
			}
		}
		//離したとき
		else if (Input.GetKeyUp(KeyCode.Space)) {
			boxCollider.isTrigger = true;
			this.transform.position = startPotision;
		} else {
			boxCollider.isTrigger = false;
			power = 1.0f;
		}
	}
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			other.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, Mathf.Sin(Mathf.PI / 6.0f), Mathf.Cos(Mathf.PI / 6.0f)) * power * 100);
			power = 1.0f;
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			boxCollider.isTrigger = false;
		}
	}
}
