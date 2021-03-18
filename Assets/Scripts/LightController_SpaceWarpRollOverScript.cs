using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_SpaceWarpRollOverScript : LightController_CommonScript{
	public Material lightingMaterial;
	public Material unlightingMaterial;
	private MeshRenderer meshRenderer;
	
	void Start(){
		CommonStart();
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material = unlightingMaterial;
	}

	void Update(){
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Ball")) {
			childrenScript.ForEach(x => x.SetLight(true));
			meshRenderer.material = lightingMaterial;
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Ball")) {
			meshRenderer.material = unlightingMaterial;
		}
	}
}
