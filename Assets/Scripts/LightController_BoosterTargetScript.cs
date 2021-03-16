using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_BoosterTargetScript : LightController_CommonScript {
	
	void Start(){
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		foreach (Transform transform in transform) {
			childrenLight.Add(transform.gameObject);
		}
		childrenLight.OrderByDescending(value => value.transform.position.z);
		childrenScript = childrenLight.Select(value => value.GetComponent<LightScript>()).ToList();
	}

	void Update(){
		if (IsAllLighting()) {
			SetAllLight(false);
			mainSystem.AddScore(5000, "Booster");
		}
	}
}
