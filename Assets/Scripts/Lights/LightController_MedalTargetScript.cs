using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_MedalTargetScript : LightControllerWithTarget_BasicScript {

	protected override void Start() {
		base.Start();
		childrenLight.Reverse();
		childrenScript.Reverse();
		lightingDuration = 30f;
	}
	public override void ActiveFunctionOfLevel() {
		switch (level) {
			case 0:
				break;
			case 1:
				mainSystem.AddScore(10000,"Level One Commendation");
				break;
			case 2:
				mainSystem.AddScore(50000,"Level Two Commendation");
				break;
			case 3:
				mainSystem.AddLife(1, "Level Three Commendation");
				break;
		}
	}
}
