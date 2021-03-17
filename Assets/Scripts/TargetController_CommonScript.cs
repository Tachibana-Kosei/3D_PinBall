using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TargetController_CommonScript : MonoBehaviour {
	private List<TargetScript> childrenTargetScript;

	void Start() {
		childrenTargetScript = GetComponentsInChildren<TargetScript>().ToList();
	}

	void Update() {

	}

	public bool IsEveryDropped() {
		return childrenTargetScript.All(x => !x.isGetUp);
	}

	public void SetAllTarget(bool isGetUp) {
		childrenTargetScript.ForEach(x => x.SetState(isGetUp));
	}
}
