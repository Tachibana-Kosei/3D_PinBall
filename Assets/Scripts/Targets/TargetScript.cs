﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour {
	private Vector3 startPosition;
	public bool isGetUp = true;
	private BoxCollider boxCollider;

	private void Start() {
		boxCollider = GetComponent<BoxCollider>();
		startPosition = transform.position;
		SetState(true);
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Ball")) {
			SetState(false);
		}
	}

	public void SetState(bool isGetUp) {
		this.isGetUp = isGetUp;
		boxCollider.isTrigger = !isGetUp;
		Vector3 setPosition;
		if (isGetUp) {
			setPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
		} else {
			setPosition = new Vector3(startPosition.x, startPosition.y - transform.localScale.y * 0.4f * Mathf.Sqrt(3), startPosition.z + transform.localScale.y * 0.4f);
		}
		transform.position = setPosition;
	}
}