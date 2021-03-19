using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LightControllerWithTarget_MedalScript : LightControllerWithTarget_BasicScript {

	protected override void Start() {
		base.Start();
		childrenLight.Reverse();
		childrenScript.Reverse();
		lightingDuration = 30f;
	}

	public override void FunctionByLevel(bool levelUp) {
		switch (level) {
			case 0:
				break;

			case 1:
				if (levelUp) mainSystem.AddScore(10000, "Level One Commendation");
				break;

			case 2:
				if (levelUp) mainSystem.AddScore(50000, "Level Two Commendation");

				break;

			case 3:
				if (levelUp) mainSystem.AddLife(1, "Level Three Commendation");

				break;
		}
	}
}
