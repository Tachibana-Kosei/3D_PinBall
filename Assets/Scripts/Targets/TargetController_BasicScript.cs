using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class TargetController_BasicScript : ControllerBasicScript {
	private List<TargetScript> childrenTargetScript;
	public LightControllerWithTarget_BasicScript lightController;

	protected override void Start() {
		base.Start();
		childrenTargetScript = GetComponentsInChildren<TargetScript>().ToList();
	}

	protected virtual void Update() {
		if (IsEveryDropped()) {
			SetAllTarget(true);
			lightController.SetLevel(lightController.level + 1);
		}
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
}