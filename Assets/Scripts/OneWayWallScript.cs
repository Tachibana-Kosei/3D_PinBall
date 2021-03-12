using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OneWayWallScript : MonoBehaviour {

	void Start() {

	}

	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			GetComponent<MeshCollider>().isTrigger = true;
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			GetComponent<MeshCollider>().isTrigger = false;
		}
	}
}
