using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpaceWarpRollOverScript : LightController_CommonScript{
	
	void Start(){
		CommonStart();
	}

	void Update(){
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Ball")) {
			childrenScript.ForEach(x => x.SetLight(true));
		}
	}
}
