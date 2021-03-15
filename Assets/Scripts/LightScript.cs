using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LightScript : MonoBehaviour{
	public Material lightingMaterial;
	public Material unlightingMaterial;
	public bool isLight=false;
	private MeshRenderer thisMeshRenderer;
	
	void Start(){
		thisMeshRenderer = GetComponent<MeshRenderer>();
		SetLight(false);
	}

	void Update(){
	}

	//引数のbool型で点灯状態を変える。trueで点灯。
	public void SetLight(bool isLight) {
		this.isLight = isLight;
		if (isLight) {
			thisMeshRenderer.material = lightingMaterial;
		} else {
			thisMeshRenderer.material = unlightingMaterial;
		}
	}

	//呼び出されると、自分の点灯or消灯を切り替える。
	public void ToggleLight() {
		isLight = !isLight;
		if (isLight) {
			thisMeshRenderer.material = lightingMaterial;
		} else {
			thisMeshRenderer.material = unlightingMaterial;
		}
	}
}
