using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_Re_EntryLaneScript : LightController_CommonScript {

	private void Start() {
		CommonStart();
	}

	private void Update() {
		LightingCheck();
	}

	private void LightingCheck() {
		if (IsAllLighting()) {
			SetAllLight(false);
			mainSystem.AddScore(5000, "Re_Entry");
		}
	}
}