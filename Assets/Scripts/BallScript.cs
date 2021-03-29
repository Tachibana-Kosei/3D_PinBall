using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour{
	private MainSystemScript mainSystem;
	private Rigidbody rb;
	private float max = 40;
	
	void Start(){
		mainSystem = GameObject.FindGameObjectWithTag("MainSystem").GetComponent<MainSystemScript>();
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		if (transform.position.y < -15||transform.position.y>15) {
			mainSystem.Crash();
			Destroy(gameObject);
		}

		float speed = rb.velocity.magnitude;
		if (speed>max&& mainSystem.gameState==MainSystemScript.GameState.Playing)
		{
			rb.velocity = rb.velocity.normalized * max;
		}
	}
}
