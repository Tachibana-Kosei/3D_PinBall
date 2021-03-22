using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_CommonScript : MonoBehaviour{
	protected MainSystemScript mainSystem;
	public List<GameObject> childrenLight;
	public List<LightScript> childrenScript;
	public void SetAllLight(bool isLight) {
		childrenScript.ForEach(value => value.SetLight(isLight));
	}

	public bool IsAllLighting() {
		return childrenScript.All(value => value.isLight);
	}
}
