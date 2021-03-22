using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_SpaceWarpTarget : LightController_CommonScript{
	private LightScript lightScript;
	
	void Start(){
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		lightScript = GetComponent<LightScript>();
	}

	void Update(){
		LightingCheck();
	}
	private void LightingCheck() {
		if (lightScript.isLight) {
			lightScript.SetLight(false);
			mainSystem.AddScore(5000, "SpaceWarp");
		}
	}
}
