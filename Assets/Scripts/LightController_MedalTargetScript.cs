using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_MedalTargetScript : LightController_CommonScript {

	private void Start() {
		CommonStart();
		childrenLight.Reverse();
		childrenScript.Reverse();
	}

	void Update() {
		LightingCheck();
	}
	private void LightingCheck() {
		if (IsEveryLighting()) {
			SetAllLight(false);
			mainSystem.AddScore(5000, "MedalTarget");
		}
	}
}
