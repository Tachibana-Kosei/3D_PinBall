using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OneWayWallScript : MonoBehaviour {

	private MeshCollider thisMesh;
	void Start() {
		thisMesh = GetComponent<MeshCollider>();
		thisMesh.isTrigger = false;
		thisMesh.enabled = false;
	}

	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			thisMesh.enabled = false;
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			thisMesh.enabled = true;
		}
	}
}
