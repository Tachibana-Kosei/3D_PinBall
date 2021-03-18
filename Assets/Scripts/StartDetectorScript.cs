using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StartDetectorScript : MonoBehaviour {
	public GameObject mainSystem;
	private MainSystemScript mainSystemScript;

	private void Start() {
		mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
	}

	private void Update() {
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Ball")) {
			mainSystemScript.PlayStart();
		}
	}
}