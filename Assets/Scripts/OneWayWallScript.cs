using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OneWayWallScript : MonoBehaviour {
	private Collider thisCollider;

	private void Start() {
		if (GetComponent<MeshCollider>()) {
			thisCollider = GetComponent<MeshCollider>();
		} else if (GetComponent<BoxCollider>()) {
			thisCollider = GetComponent<BoxCollider>();
		}
		thisCollider.enabled = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			thisCollider.enabled = false;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			thisCollider.enabled = true;
		}
	}
}