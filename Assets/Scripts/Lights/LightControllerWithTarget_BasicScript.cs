using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class LightControllerWithTarget_BasicScript : LightController_BasicScript{
	protected float lightingTime=0f;
	protected float lightingDuration;
	protected int level=0;
	protected int maxLevel;

	protected override void Start() {
		base.Start();
		maxLevel = childrenScript.Count();
	}

	public void SetLevel(int level) {
		for (int i = 0; i < maxLevel; i++) {
			childrenScript[i].SetLight(i < level);
		}
		lightingTime = 0f;
		this.level = level;
		ActiveFunctionOfLevel();
	}

	public override void Reset() {
		SetLevel(0);
	}
	public abstract void ActiveFunctionOfLevel();
}
