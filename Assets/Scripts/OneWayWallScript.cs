using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OneWayWallScript : MonoBehaviour {

	private Collider col;
	void Start() {
		col = GetComponent<Collider>();
		col.enabled = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			col.enabled = false;
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			col.enabled = true;
		}
	}
}
