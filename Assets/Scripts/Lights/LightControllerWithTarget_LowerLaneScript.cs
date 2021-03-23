using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lights;
using UnityEngine;
using UnityEngine.UI;

public class LightControllerWithTarget_LowerLaneScript : LightControllerWithTarget_BasicScript{
	
	protected override void Start()
	{
		base.Start();
		lightingDuration = 100000;
		var temp = childrenScript[1];
		childrenScript[1] = childrenScript[2];
		childrenScript[2] = temp;
	}

	protected override void FunctionByLevel(bool levelUp)
	{
	}
}
