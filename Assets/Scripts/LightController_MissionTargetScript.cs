using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_MissionTargetScript : LightController_CommonScript {

	void Start() {
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		childrenLight = GetComponentsInChildren<GameObject>().OrderByDescending(value => value.transform.position.z).ToList();
		childrenScript = childrenLight.Select(value => value.GetComponent<LightScript>()).ToList();
	}

	void Update() {
		LightingCheck();
	}
	private void LightingCheck() {
		if (IsAllLighting()) {
			SetAllLight(false);
			mainSystem.AddScore(5000, "MissionTarget");
		}
	}
}
