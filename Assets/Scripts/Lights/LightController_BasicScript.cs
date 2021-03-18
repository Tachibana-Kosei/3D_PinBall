using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class LightController_BasicScript : ControllerBasicScript {
	protected MainSystemScript mainSystem;
	public List<GameObject> childrenLight;
	public List<LightScript> childrenScript;

	protected virtual void Start() {
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		childrenLight = GetComponentsInChildren<Transform>().Where(x=>x.GetComponent<LightScript>()).Select(x => x.gameObject).ToList();
		float disX = childrenLight.Max(x => x.transform.position.x) - childrenLight.Min(x => x.transform.position.x);
		float disZ = childrenLight.Max(x => x.transform.position.z) - childrenLight.Min(x => x.transform.position.z);
		if (disX > disZ) {
			childrenLight.OrderBy(x => x.transform.position.x);
		} else {
			childrenLight.OrderBy(x => x.transform.position.z);
		}
		childrenScript = childrenLight.Select(x => x.GetComponent<LightScript>()).ToList();
	}

	public virtual void SetAllLight(bool isLight) {
		childrenScript.ForEach(value => value.SetLight(isLight));
	}

	public bool IsEveryLighting() {
		return childrenScript.All(value => value.isLight);
	}

	public override void Reset() {
		SetAllLight(false);
	}
}