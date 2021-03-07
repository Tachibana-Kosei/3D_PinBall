using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CrachDetectorScript : MonoBehaviour{
	private GameObject mainSystem;
	private MainSystemScript mainSystemScript;
	void Start(){
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem");
		mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ball")) {
			Destroy(other.gameObject);
			mainSystemScript.Crash();
		}
	}
}
