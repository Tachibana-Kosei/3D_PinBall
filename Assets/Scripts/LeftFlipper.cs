using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lights;
using UnityEngine;
using UnityEngine.UI;

public class LeftFlipper : MonoBehaviour {
	public float spring = 4000;
	public float openAngle = 60;
	public float closeAngle = -35;

	private HingeJoint hjL;

	private JointSpring jL;
	[SerializeField]private GameObject lightController_ReEntry;
	private LightController_Re_EntryLaneScript lightControllerReEntryLaneScript;
    
	private AudioSource audioSource;
   
	public AudioClip SE1;

	public AudioClip SE2;

	// Start is called before the first frame update
	void Start() {

		hjL = GetComponent<HingeJoint>();

		hjL.useSpring = true;

		jL = hjL.spring;

		lightControllerReEntryLaneScript = lightController_ReEntry.GetComponent<LightController_Re_EntryLaneScript>();

		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown("f")) {
			jL.spring = spring;
			jL.targetPosition = openAngle;
			hjL.spring = jL;
			lightControllerReEntryLaneScript.LightMove_toL();
			audioSource.PlayOneShot(SE1);
		}
		if (Input.GetKeyUp("f")) {
			jL.spring = spring;
			jL.targetPosition = closeAngle;
			hjL.spring = jL;
			audioSource.PlayOneShot(SE2);
		}
	}
}
