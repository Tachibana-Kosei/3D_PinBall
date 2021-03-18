using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_BoosterTargetScript : LightControllerWithTarget_BasicScript {

	protected override void Start() {
		base.Start();
		lightingDuration = 60f;
	}
	public override void ActiveFunctionOfLevel() {
		switch (level) {
			case 0:
				mainSystem.bonusMultiplyRate = 1;
				break;

			case 1:
				mainSystem.bonusMultiplyRate = 5;
				Debug.Log("Flugs Upgraded");
				break;

			case 2:
				mainSystem.jackpotEnable = true;
				Debug.Log("Jackpot Activated");
				break;

			case 3:
				mainSystem.bonusEnable = true;
				Debug.Log("Bonus Activated");
				break;

			case 4:
				mainSystem.bonusHold = true;
				Debug.Log("Bonus Hold");
				break;
		}
	}
}
