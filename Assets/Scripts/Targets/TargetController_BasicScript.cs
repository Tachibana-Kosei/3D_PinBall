using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class TargetController_BasicScript : ControllerBasicScript {
	private List<TargetScript> childrenTargetScript;
	public LightControllerWithTarget_BasicScript lightController;
	private int delayFrameCount = 10;
	private bool coroutineActive = false;

	protected override void Start() {
		base.Start();
		childrenTargetScript = GetComponentsInChildren<TargetScript>().ToList();
	}

	protected virtual void Update() {
		if (mainSystem.gameState != MainSystemScript.GameState.OnStandby) {
			if (IsEveryDropped() && !coroutineActive) {
				StartCoroutine(LevelUpAndDelayGetUp(delayFrameCount));
				coroutineActive = true;
			}
		}
	}

	private IEnumerator LevelUpAndDelayGetUp(int delayFrameCount) {
		lightController.SetLevel(lightController.level + 1);
		for (int i = 0; i < delayFrameCount; i++) {
			if (mainSystem.gameState == MainSystemScript.GameState.OnStandby) {
				yield break;
			} else {
				yield return null;
			}
		}
		SetAllTarget(true);
		coroutineActive = false;
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