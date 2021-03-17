using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_HazardTargetScript : LightController_CommonScript {

	private void Start() {
		CommonStart();
	}

	void Update() {
		LightingCheck();
	}
	private void LightingCheck() {
		if (IsAllLighting()) {
			SetAllLight(false);
			mainSystem.AddScore(5000, "HazardTarget");
		}
	}
}
