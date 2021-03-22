using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_FieldMultiplierScript : LightController_CommonScript {

	void Start() {
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		foreach (Transform transform in transform) {
			childrenLight.Add(transform.gameObject);
		}
		childrenLight.OrderBy(value => value.transform.position.x);
		childrenScript = childrenLight.Select(value => value.GetComponent<LightScript>()).ToList();
	}

	void Update() {
		LightingCheck();
	}

	private void LightingCheck() {
		if (IsAllLighting()) {
			SetAllLight(false);
			mainSystem.AddScore(5000, "FieldMultiplier");
		}
	}
}
