using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class LightControllerWithTarget_BasicScript : LightController_BasicScript{
	protected float lightingTime=0f;
	protected float lightingDuration;
	public int level=0;
	public int maxLevel;

	protected override void Start() {
		base.Start();
		maxLevel = childrenScript.Count();
	}

	public void SetLevel(int level) {
		bool levelUp = level > this.level;
		level = Math.Min(level, maxLevel);
		for (int i = 0; i < maxLevel; i++) {
			childrenScript[i].SetLight(i < level);
		}
		lightingTime = 0f;
		this.level = level;
		FunctionByLevel(levelUp);
	}

	public override void Reset() {
		SetLevel(0);
	}
	public abstract void FunctionByLevel(bool levelUp);
}
