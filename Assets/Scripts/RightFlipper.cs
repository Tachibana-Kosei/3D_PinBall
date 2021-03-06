using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lights;
using UnityEngine;
using UnityEngine.UI;

public class RightFlipper : MonoBehaviour {
	public float spring = 4000;
	public float openAngle = 60;
	public float closeAngle = -35;

	private HingeJoint hjR;

	private JointSpring jR;
	[SerializeField]private GameObject lightController_ReEntry;
	private LightController_Re_EntryLaneScript lightControllerReEntryLaneScript;

	private AudioSource audioSource;

	public AudioClip SE1;

	public AudioClip SE2;
	// Start is called before the first frame update
	void Start() {

		hjR = GetComponent<HingeJoint>();

		hjR.useSpring = true;

		jR = hjR.spring;
		lightControllerReEntryLaneScript = lightController_ReEntry.GetComponent<LightController_Re_EntryLaneScript>();

		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown("j")) {
			jR.spring = spring;
			jR.targetPosition = -openAngle;
			hjR.spring = jR;
			lightControllerReEntryLaneScript.LightMove_toR();
			audioSource.PlayOneShot(SE1);
		}
		if (Input.GetKeyUp("j")) {
			jR.spring = spring;
			jR.targetPosition = -closeAngle;
			hjR.spring = jR;
			audioSource.PlayOneShot(SE2);
		}
	}
}
