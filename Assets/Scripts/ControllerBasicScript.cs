using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class ControllerBasicScript : MonoBehaviour {
	protected MainSystemScript mainSystem;
	protected virtual void Start() {
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		mainSystem.controllers.Add(this);
	}
	public abstract void Reset();
}
