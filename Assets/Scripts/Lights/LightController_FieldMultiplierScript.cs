using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightController_FieldMultiplierScript : LightControllerWithTarget_BasicScript {

	protected override void Start() {
		base.Start();
		lightingDuration = 60f;
	}

	public override void ActiveFunctionOfLevel() {
		switch (level) {
			case 0:
				mainSystem.fieldMultiplyRate = 1;
				break;

			case 1:
				mainSystem.fieldMultiplyRate = 2;
				Debug.Log("Field Multiply x2");
				break;

			case 2:
				mainSystem.fieldMultiplyRate = 3;
				Debug.Log("Field Multiply x3");
				break;

			case 3:
				mainSystem.fieldMultiplyRate = 5;
				Debug.Log("Field Multiply x5");
				break;

			case 4:
				mainSystem.fieldMultiplyRate = 10;
				Debug.Log("Field Multiply x10");
				break;
		}
	}
}