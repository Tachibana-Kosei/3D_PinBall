using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour{
	private MainSystemScript mainSystem;
	
	void Start(){
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
	}

	void Update(){
		if (transform.position.y < -15) {
			mainSystem.Crash();
			Destroy(gameObject);
		}
	}
}
