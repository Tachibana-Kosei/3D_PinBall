using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class TargetController_BasicScript : ControllerBasicScript {
	private List<TargetScript> childrenTargetScript;
	public GameObject lightController;

	protected virtual void Start() {
		childrenTargetScript = GetComponentsInChildren<TargetScript>().ToList();
	}

	public bool IsEveryDropped() {
		return childrenTargetScript.All(x => !x.isGetUp);
	}

	public void SetAllTarget(bool isGetUp) {
		childrenTargetScript.ForEach(x => x.SetState(isGetUp));
	}

	public override void Reset() {
		SetAllTarget(true);
	}

	protected abstract void OnEveryDropped();
}
