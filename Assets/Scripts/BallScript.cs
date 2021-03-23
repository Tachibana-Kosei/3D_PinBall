using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour{
	private MainSystemScript mainSystem;
	private Rigidbody rb;
	private float max = 45;
	
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
		if (speed>max)
		{
			Debug.Log("speed");
			rb.velocity = rb.velocity.normalized * max;
		}
	}
}
